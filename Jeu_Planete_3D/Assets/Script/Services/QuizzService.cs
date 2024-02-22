using System;
using System.Collections;
using Script.Core.Quizz.Questions;
using UnityEngine;

namespace Script.Services
{
    public class QuizzService : MonoBehaviour
    {

        [SerializeField] private Tuple<QuestionType, ShowQuestion>[] shows;
        private IQuestionCorrector<Question> corrector;
        private Quizz quizz;
        public int indexCurrentQuestion { get; private set; } = 0;
        [SerializeField] private WebDatabaseAccessInterface linkWeb;

        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject endPanel;
        [SerializeField] private Tuple<QuestionType, GameObject>[] questionPanels;

        public bool correctionDone { get; private set; } = false;



        public IEnumerator InitQuizz(int nbQcu, int nbTrueFalse, int nbManipulation)
        {
            // Get the random question ids
            CoroutineWithData<int[]> dataRandomQs = new CoroutineWithData<int[]>(this,
                linkWeb.GetRandomQuestions(nbQcu, nbTrueFalse, nbManipulation));
            yield return dataRandomQs.coroutine;
            int[] qids = dataRandomQs.result;
            
            Question[] questions = new Question[qids.Length];
            for (int i = 0; i < qids.Length; ++i)
            {
                CoroutineWithData<Question> dataQuestion =
                    new CoroutineWithData<Question>(this, linkWeb.GetQuestion(qids[i]));
                yield return dataQuestion.coroutine;
                questions[i] = dataQuestion.result;
            }
        }

        public void StartQuizz()
        {
            startPanel.SetActive(false);
            CurrentQuestion();
        }

        public QuestionType GetCurrentQuestionType()
        {
            return quizz.questions[indexCurrentQuestion].type;
        }

        public bool IsQuizzStarted()
        {
            return quizz.started;
        }

        public void CurrentQuestion()
        {
            QuestionType questionType = GetCurrentQuestionType();
            
            if (questionType == QuestionType.Qcu)
            {
                QuestionQCU question = (QuestionQCU) quizz.questions[indexCurrentQuestion];
                ShowQCU show = (ShowQCU) GetAssociatedShowQuestion(questionType);
                show.ShowTheQuestion(question);
                corrector = new CorrectorQCU(question, show.GetChoices());
            }
            
            else if (questionType == QuestionType.TrueFalse)
            {
                QuestionTrueFalse question = (QuestionTrueFalse) quizz.questions[indexCurrentQuestion];
                ShowTrueFalse show = (ShowTrueFalse) GetAssociatedShowQuestion(questionType);
                show.ShowTheQuestion(question);
                corrector = new CorrectorQCU(question, show.GetChoices());
            }

            else if (questionType == QuestionType.Manipulation)
            {
                QuestionManipulation question = (QuestionManipulation) quizz.questions[indexCurrentQuestion];
                ShowManipulation show = (ShowManipulation) GetAssociatedShowQuestion(questionType);
                show.ShowTheQuestion(question);
                corrector = new CorrectorManipulation(question, show.GetOrbit(), show.GetRotation(), show.GetCorrectionText());
            }
            
            ShowAssociatedPanel(questionType);
            
        }

        private ShowQuestion GetAssociatedShowQuestion(QuestionType type)
        {
            for (int i = 0; i < shows.Length; ++i)
            {
                if (shows[i].Item1 == type) return shows[i].Item2;
            }

            return null;
        }
        
        private void ShowAssociatedPanel(QuestionType type)
        {
            for (int i = 0; i < shows.Length; ++i)
            {
                questionPanels[i].Item2.SetActive(questionPanels[i].Item1 == type);
            }
        }

        public bool NextQuestion()
        {
            ++indexCurrentQuestion;
            if (indexCurrentQuestion < quizz.questions.Length)
            {
                CurrentQuestion();
                // There was still a question to shows so the quizz must continue
                return true;
            }
            // There is no next question, the quizz must end
            return false;
            
        }

        public void EndOfQuizz()
        {
            ShowAssociatedPanel(QuestionType.None);
            endPanel.SetActive(true);
        }

        public string[] GetRestrictableToEnable()
        {
            QuestionType qType = GetCurrentQuestionType();
            if (!correctionDone) // User can answer, correction not started yet
            {
                if (qType == QuestionType.Qcu)
                {
                    return new []{"Detector Cycle", "SubScript AutoMotion"};
                }
                else if (qType == QuestionType.TrueFalse)
                {
                    QuestionTrueFalse tmp = (QuestionTrueFalse)quizz.questions[indexCurrentQuestion];
                    string[] array = new string[0];
                    if (!tmp.IsOrbitFixed())
                    {
                        Array.Resize(ref array, array.Length + 1);
                        array[array.Length - 1] = "Cycle Orbit";
                    }
                    if (!tmp.IsRotationFixed())
                    {
                        Array.Resize(ref array, array.Length + 1);
                        array[array.Length - 1] = "Cycle Rotation";
                    }
                    return array;
                }
                else if (qType == QuestionType.Manipulation)
                {
                    return new[] { "Detector Cycle" };
                }
                else return new string[0];
            }
            else // Correction done for the current question
            {
                if (qType == QuestionType.Qcu)
                {
                    return new []{"Detector Cycle", "SubScript AutoMotion"};
                }
                else if (qType == QuestionType.TrueFalse)
                {
                    return new []{"Detector Cycle", "SubScript AutoMotion"};
                }
                else if (qType == QuestionType.Manipulation)
                {
                    return new string[0];
                }
                else return new string[0];
            }
        }
        
        public string[] GetRestrictableToDisableAndRestrict()
        {
            QuestionType qType = GetCurrentQuestionType();
            if (!correctionDone) // User can answer, correction not started yet
            {
                if (qType == QuestionType.Qcu)
                {
                    return new string[0];
                }
                else if (qType == QuestionType.TrueFalse)
                {
                    QuestionTrueFalse tmp = (QuestionTrueFalse)quizz.questions[indexCurrentQuestion];
                    string[] array = new string[0];
                    if (tmp.IsOrbitFixed())
                    {
                        Array.Resize(ref array, array.Length + 1);
                        array[array.Length - 1] = "Cycle Orbit";
                    }
                    if (tmp.IsRotationFixed())
                    {
                        Array.Resize(ref array, array.Length + 1);
                        array[array.Length - 1] = "Cycle Rotation";
                    }

                    return array;
                }
                else if (qType == QuestionType.Manipulation)
                {
                    return new []{"SubScript AutoMotion"};
                }
                else return new string[0];
            }
            else // Correction done for the current question
            {
                if (qType == QuestionType.Qcu)
                {
                    return new string[0];
                }
                else if (qType == QuestionType.TrueFalse)
                {
                    return new string[0];
                }
                else if (qType == QuestionType.Manipulation)
                {
                    return new []{"Detector Cycle", "SubScript AutoMotion"};
                }
                else return new string[0];
            }
        }
        

        public void StartCorrection()
        {
            corrector.Correct();
        }

        public void RegisterUserCurrentAnswerInDatabase()
        {
            StartCoroutine(linkWeb.AddUserAnswer(quizz.questions[indexCurrentQuestion].id, corrector.startTime.ToString("u"),
                corrector.correct));
        }


    }
}
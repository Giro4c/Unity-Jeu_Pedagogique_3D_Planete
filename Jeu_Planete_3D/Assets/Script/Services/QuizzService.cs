using System;
using System.Collections;
using Script.Core.Quizz.Questions;
using Script.WebData;
using Unity.VisualScripting;
using UnityEngine;

namespace Script.Services
{
    public class QuizzService : MonoBehaviour
    {

        [SerializeField] private QuestionType[] associatedTypes;
        [SerializeField] private ShowQuestion[] associatedShows;
        [SerializeField] private GameObject[] associatedQuestionPanels;
        private Tuple<QuestionType, ShowQuestion, GameObject>[] associationsQuestions = new Tuple<QuestionType, ShowQuestion, GameObject>[0];
        
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject endPanel;
        
        private IQuestionCorrector<Question> corrector;
        private Quizz quizz = new Quizz();
        public int indexCurrentQuestion { get; private set; } = 0;
        public bool correctionDone { get; private set; } = false;

        [SerializeReference] private WebDatabaseAccess linkWeb;

        
        
        /// <summary>
        /// <para>
        /// Initialize the associationsQuestions Tuple array based on the values stored in the 3 serializable arrays. The items of a Tuple number X are :<br/>
        /// - QuestionType from associatedTypes<br/>
        /// - ShowQuestion from associatedShows<br/>
        /// - GameObject from associatedQuestionPanels<br/>
        /// Each at the index X in their respective array.
        /// </para>
        /// </summary>
        /// <exception cref="Exception">The arrays are not of the same size. The Tuple array cannot be initialized.</exception>
        public void Initialize()
        {
            // Verify that all arrays are of the same size. If not then throw an exception
            if (associatedTypes.Length != associatedQuestionPanels.Length ||
                associatedTypes.Length != associatedShows.Length)
                throw new Exception(
                    "Arrays associatedTypes, associatedShows and associatedQuestionPanels must be of same length.");
            
            // Initialize size of Tuple array
            Tuple<QuestionType, ShowQuestion, GameObject>[] array = new Tuple<QuestionType, ShowQuestion, GameObject>[associatedTypes.Length];
            
            // Fill the Tuple array
            for (int i = 0; i < associatedTypes.Length; ++i)
            {
                array[i] = new Tuple<QuestionType, ShowQuestion, GameObject>(associatedTypes[i],
                    associatedShows[i], associatedQuestionPanels[i]);
            }

            associationsQuestions = array;
            // DebugInitialize(array);
        }

        // private void DebugInitialize(Tuple<QuestionType, ShowQuestion, GameObject>[] array)
        // {
        //     Debug.Log("Start Debug Init array tuple quizz service");
        //     Debug.Log("Length : " + array.Length);
        //     foreach (Tuple<QuestionType, ShowQuestion, GameObject> tuple in array)
        //     {
        //         Debug.Log("Item 1 : " + tuple.Item1);
        //         Debug.Log("Item 2 : " + tuple.Item2.GetType().Name);
        //         Debug.Log("Item 3 : " + tuple.Item3);
        //     }
        //     Debug.Log("End Debug Init array tuple quizz service");
        // }
        
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

            quizz = new Quizz(questions, false);
            // DebugQuizz();
        }

        // public void DebugQuizz()
        // {
        //     print("Quizz Verif");
        //     print(quizz.started);
        //     print(quizz.questions.Length);
        //     foreach (Question q in quizz.questions)
        //     {
        //         print("Question :");
        //         print(q.id);
        //         print(q.type);
        //         print(q.header);
        //         print(q.GetType().Name);
        //     }
        // }

        public void StartQuizz()
        {
            startPanel.SetActive(false);
            quizz.started = true;
            correctionDone = false;
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
                // DebugShowQuestionChoicesButtons(show.GetChoices());
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
        
        // private void DebugShowQuestionChoicesButtons(ChoiceButton[] choices)
        // {
        //     Debug.Log("Start Debug show QCU");
        //     Debug.Log("Verify choices array : Length = " + choices.Length);
        //     foreach (ChoiceButton choice in choices)
        //     {
        //         Debug.Log("Value : " + choice.choice.value + " --- Correct ? " + choice.choice.correct + " --- Selected ? " + choice.selected);
        //         Debug.Log("Button : " + choice.GetButton());
        //     }
        //     Debug.Log("End Debug show QCU");
        //
        // }

        private int GetIndexAssociation(QuestionType type)
        {
            for (int i = 0; i < associationsQuestions.Length; ++i)
            {
                if (associationsQuestions[i].Item1 == type) return i;
            }
            return -1;
        }
        
        private ShowQuestion GetAssociatedShowQuestion(QuestionType type)
        {
            for (int i = 0; i < associationsQuestions.Length; ++i)
            {
                if (associationsQuestions[i].Item1 == type) return associationsQuestions[i].Item2;
            }

            return null;
        }
        
        private void ShowAssociatedPanel(QuestionType type)
        {
            for (int i = 0; i < associationsQuestions.Length; ++i)
            {
                associationsQuestions[i].Item3.SetActive(associationsQuestions[i].Item1 == type);
            }
        }

        public bool NextQuestion()
        {
            ++indexCurrentQuestion;
            correctionDone = false;
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

        // public string[] GetRestrictableToEnable()
        // {
        //     QuestionType qType = GetCurrentQuestionType();
        //     if (!correctionDone) // User can answer, correction not started yet
        //     {
        //         if (qType == QuestionType.Qcu)
        //         {
        //             return new []{"Detector Cycle", "SubScript AutoMotion"};
        //         }
        //         else if (qType == QuestionType.TrueFalse)
        //         {
        //             QuestionTrueFalse tmp = (QuestionTrueFalse)quizz.questions[indexCurrentQuestion];
        //             string[] array = new string[0];
        //             if (!tmp.IsOrbitFixed())
        //             {
        //                 Array.Resize(ref array, array.Length + 1);
        //                 array[array.Length - 1] = "Cycle Orbit";
        //             }
        //             if (!tmp.IsRotationFixed())
        //             {
        //                 Array.Resize(ref array, array.Length + 1);
        //                 array[array.Length - 1] = "Cycle Rotation";
        //             }
        //             return array;
        //         }
        //         else if (qType == QuestionType.Manipulation)
        //         {
        //             return new[] { "Detector Cycle" };
        //         }
        //         else return new string[0];
        //     }
        //     else // Correction done for the current question
        //     {
        //         if (qType == QuestionType.Qcu)
        //         {
        //             return new []{"Detector Cycle", "SubScript AutoMotion"};
        //         }
        //         else if (qType == QuestionType.TrueFalse)
        //         {
        //             return new []{"Detector Cycle", "SubScript AutoMotion"};
        //         }
        //         else if (qType == QuestionType.Manipulation)
        //         {
        //             return new string[0];
        //         }
        //         else return new string[0];
        //     }
        // }
        
        public string[] GetRestrictableToDisableAndRestrict()
        {
            if (indexCurrentQuestion < 0 || indexCurrentQuestion >= quizz.questions.Length) return new string[0];
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
                        Array.Resize(ref array, array.Length + 2);
                        array[array.Length - 2] = "Detector Cycle Orbit";
                        array[array.Length - 1] = "AutoMotion Cycle Orbit";
                    }
                    if (tmp.IsRotationFixed())
                    {
                        Array.Resize(ref array, array.Length + 2);
                        array[array.Length - 2] = "Detector Cycle Rotation";
                        array[array.Length - 1] = "AutoMotion Cycle Rotation";
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
            correctionDone = true;
        }

        public void RegisterUserCurrentAnswerInDatabase()
        {
            StartCoroutine(linkWeb.AddUserAnswer(quizz.questions[indexCurrentQuestion].id, corrector.startTime.ToString("u").Replace("Z", ""),
                corrector.correct));
        }


    }
}
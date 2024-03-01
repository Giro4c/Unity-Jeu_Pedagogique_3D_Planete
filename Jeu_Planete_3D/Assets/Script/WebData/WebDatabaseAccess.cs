using System;
using System.Collections;
using System.Globalization;
using Script.Core.Quizz.Questions;
using Script.Services;
using UnityEngine;
using UnityEngine.Networking;

namespace Script.WebData
{
    
    [CreateAssetMenu(fileName = "DatabaseAccess", menuName = "ScriptableObjects/WebDatabaseAccess", order = 1)]
    public class WebDatabaseAccess : ScriptableObject, WebDatabaseAccessInterface
    {
        [SerializeField] private WebConnection _webDatabaseConnection;
        
        public IEnumerator NewGame(string platform)
        {
            string url = _webDatabaseConnection.GetHost() + "/addNewGame.php?plateforme=" + platform;
            Debug.Log(url);
        
            UnityWebRequest wwwNewGame = UnityWebRequest.Get(url);
            yield return wwwNewGame.SendWebRequest();
            if (wwwNewGame.error != null)
            {
                Debug.LogError(wwwNewGame.error);
            }
            else
            {
                Debug.Log("Page New Game Loaded");
                Debug.Log(wwwNewGame.downloadHandler.text);
            }
        }

        public IEnumerator AbortGame()
        {
            string url = _webDatabaseConnection.GetHost() + "/abortOnGoingGame.php";
            Debug.Log(url);
        
            UnityWebRequest wwwAbortGame = UnityWebRequest.Get(url);
            yield return wwwAbortGame.SendWebRequest();
            if (wwwAbortGame.error != null)
            {
                Debug.LogError(wwwAbortGame.error);
            }
            else
            {
                Debug.Log("Page Abort Game Loaded");
                Debug.Log(wwwAbortGame.downloadHandler.text);
            }
        }

        public IEnumerator EndGame()
        {
            string url = _webDatabaseConnection.GetHost() + "/endGame.php";
            Debug.Log(url);
        
            UnityWebRequest wwwAbortGame = UnityWebRequest.Get(url);
            yield return wwwAbortGame.SendWebRequest();
            if (wwwAbortGame.error != null)
            {
                Debug.LogError(wwwAbortGame.error);
            }
            else
            {
                Debug.Log("Page End Game Loaded");
                Debug.Log(wwwAbortGame.downloadHandler.text);
            }
        }

        public IEnumerator AddInteraction(string type, float value, bool quizzStarted)
        {
            string strVarURLGet = "";
            strVarURLGet = "type=" + type + "&value=" + value.ToString().Replace(',', '.') + "&isEval=";
            if (quizzStarted)
            {
                strVarURLGet += "1";
            }
            else
            {
                strVarURLGet += "0";
            }
            string url = _webDatabaseConnection.GetHost() + "/addInteraction.php?" + strVarURLGet;
            Debug.Log(url);
        
            UnityWebRequest wwwInteract = UnityWebRequest.Get(url);
            yield return wwwInteract.SendWebRequest();
            if (wwwInteract.error != null)
            {
                Debug.LogError(wwwInteract.error);
            }
            else
            {
                Debug.Log("Page Interaction " + type + " Loaded");
                Debug.Log(wwwInteract.downloadHandler.text);
            }
        }

        public IEnumerator GetQuestion(int qid)
        {
            string strVarURLGet = "qid=" + qid;
            string url = _webDatabaseConnection.GetHost() + "/question.php?" + strVarURLGet;
            Debug.Log(url);

            UnityWebRequest wwwInteract = UnityWebRequest.Get(url);
            yield return wwwInteract.SendWebRequest();
            // Created var to store the html content shower will have to parse through
            string webPage = "";
            // Checks if error
            if (wwwInteract.error != null)
            {
                Debug.LogError(wwwInteract.error);
                /* In case of emergency if its impossible to connect to the host since the start,
                 read the expected html page content for a known question and store the value for later used*/
                TextAsset questionTextAsset = Resources.Load<TextAsset>("WebEmergency/Questions/" + qid);
                webPage = questionTextAsset.text;
            }
            else // No error, Web Page is loaded
            {
                Debug.Log(wwwInteract.downloadHandler.text); // le texte de la page
                webPage = wwwInteract.downloadHandler.text;
            }
            
            // Init du htmlParser
            StringHTMLParser htmlParser = new StringHTMLParser(webPage);
            
            string type = htmlParser.getHTMLContainerContent("p", null, "Type");
            string header = htmlParser.getHTMLContainerContent("p", null, "Enonce");
            
            if (type.Equals("QCU")) // Question of type QCU or TrueFalse
            {
                string correctAnswer = htmlParser.getHTMLContainerContent("p", null, "BonneRep");
                Choice[] choices = new Choice[4];
                for (int i = 1; i <= choices.Length; ++i)
                {
                    string val = htmlParser.getHTMLContainerContent("p", null, "Rep" + i);
                    choices[i - 1] = new Choice(val, val.Equals(correctAnswer));
                }

                yield return new QuestionQCU(qid, QuestionType.Qcu, header, choices);
                
            }
            
            else if (type.Equals("QUESINTERAC")) // Question of type Manipulation
            {
                // Change Culture info for String to float conversions
                CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                ci.NumberFormat.CurrencyDecimalSeparator = ".";

                // Correct Orbit
                string valExtractor = htmlParser.getHTMLContainerContent("p", null, "BonneRepValeur_orbit");
                float correctOrbit;
                if (valExtractor != null && !valExtractor.Equals(""))
                {
                    correctOrbit = float.Parse(valExtractor, NumberStyles.Any, ci);
                    correctOrbit %= 1f;
                }
                else
                {
                    correctOrbit = -1;
                }
                
                // Correct Rotation
                valExtractor = htmlParser.getHTMLContainerContent("p", null, "BonneRepValeur_rotation");
                float correctRotation;
                if (valExtractor != null && !valExtractor.Equals(""))
                {
                    correctRotation = float.Parse(valExtractor, NumberStyles.Any, ci);
                    correctRotation %= 1f;
                }
                else
                {
                    correctRotation = -1;
                }
                
                // Margin Orbit
                valExtractor = htmlParser.getHTMLContainerContent("p", null, "Marge_Orbit");
                float orbitMargin;
                if (valExtractor != null && !valExtractor.Equals(""))
                {
                    orbitMargin = float.Parse(valExtractor, NumberStyles.Any, ci);
                    if (orbitMargin > 0.5f)
                    {
                        orbitMargin %= 0.5f;
                    }
                }
                else
                {
                    orbitMargin = -1;
                }
                
                // Margin Rotation
                valExtractor = htmlParser.getHTMLContainerContent("p", null, "Marge_Rotation");
                float rotationMargin;
                if (valExtractor != null && !valExtractor.Equals(""))
                {
                    rotationMargin = float.Parse(valExtractor, NumberStyles.Any, ci);
                    if (rotationMargin > 0.5f)
                    {
                        rotationMargin %= 0.5f;
                    }
                }
                else
                {
                    rotationMargin = -1;
                }

                yield return new QuestionManipulation(qid, QuestionType.Manipulation, header, correctOrbit, correctRotation, orbitMargin,
                    rotationMargin);
            }
            
            else if (type.Equals("VRAIFAUX")) // Question of type TrueFalse
            {
                string correctAnswer = htmlParser.getHTMLContainerContent("p", null, "BonneRep");
                Choice[] choices = {new Choice("Vrai", false), new Choice("Faux", false)};
                for (int i = 0; i < choices.Length; ++i)
                {
                    choices[i].correct = choices[i].value.Equals(correctAnswer);
                }
                // Change Culture info for String to float conversions
                CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                ci.NumberFormat.CurrencyDecimalSeparator = ".";

                // Fixed Orbit
                string valExtractor = htmlParser.getHTMLContainerContent("p", null, "Valeur_orbit");
                float fixedOrbit;
                if (valExtractor != null && !valExtractor.Equals(""))
                {
                    fixedOrbit = float.Parse(valExtractor, NumberStyles.Any, ci);
                }
                else
                {
                    fixedOrbit = -1;
                }
                
                // Fixed Rotation
                valExtractor = htmlParser.getHTMLContainerContent("p", null, "Valeur_rotation");
                float fixedRotation;
                if (valExtractor != null && !valExtractor.Equals(""))
                {
                    fixedRotation = float.Parse(valExtractor, NumberStyles.Any, ci);
                }
                else
                {
                    fixedRotation = -1;
                }
                
                yield return new QuestionTrueFalse(qid, QuestionType.TrueFalse, header, choices, fixedOrbit, fixedRotation);
            }
            
        }

        // public CoroutineWithData<Question> GetQuestionData(int qid)
        // {
        //     throw new System.NotImplementedException();
        // }

        public IEnumerator GetRandomQuestions(int nbQcu, int nbTrueFalse, int nbManipulation)
        {
            string strVarURLGet = "qcu=" + nbQcu + "&interaction=" + nbManipulation + "&vraifaux=" + nbTrueFalse;
            string url = _webDatabaseConnection.GetHost() + "/randomQuestions.php?" + strVarURLGet;
            Debug.Log(url);
        
            UnityWebRequest wwwInteract = UnityWebRequest.Get(url);
            yield return wwwInteract.SendWebRequest();
        
            string webPage = "";
            // Checks if error
            if (wwwInteract.error != null)
            {
                Debug.LogError(wwwInteract.error);
                /* In case of emergency if its impossible to connect to the host since the start,
                 read the expected html page content for a known question and store the value for later used*/
                TextAsset questionTextAsset = Resources.Load<TextAsset>("WebEmergency/initQuizz");
                webPage = questionTextAsset.text;
            }
            else // No error, Web Page is loaded
            {
                Debug.Log(wwwInteract.downloadHandler.text); // le texte de la page
                webPage = wwwInteract.downloadHandler.text;
            }
        
            StringHTMLParser htmlParser = new StringHTMLParser(webPage);
            int totCount = nbQcu + nbManipulation + nbTrueFalse;
            int[] list = new int[totCount];
            
            for (int count = 0; count < totCount; ++count)
            {
                string extractedVal = htmlParser.getHTMLContainerContent("li", null, count.ToString());
                Debug.Log(count);
                Debug.Log(extractedVal);
                list[count] = int.Parse(extractedVal);
            }

            yield return list;

        }

        // public CoroutineWithData<int[]> GetRandomQuestionsData(int nbQcu, int nbTrueFalse, int nbManipulation)
        // {
        //     throw new System.NotImplementedException();
        // }

        public IEnumerator AddUserAnswer(int qid, string dateStart, bool correct)
        {
            string strVarURLGet = "qid=" + qid + "&start=" + dateStart + "&correct=";
            if (correct)
            {
                strVarURLGet += "1";
            }
            else
            {
                strVarURLGet += "0";
            }
            string url = _webDatabaseConnection.GetHost() + "/addQuestionAnswer.php?" + strVarURLGet;
            Debug.Log(url);
        
            UnityWebRequest wwwInteract = UnityWebRequest.Get(url);
            yield return wwwInteract.SendWebRequest();
            if (wwwInteract.error != null)
            {
                Debug.LogError(wwwInteract.error);
            }
            else // Pas d'erreur, la page est chargée
            {
                Debug.Log("Page Add User Answer Loaded");
                Debug.Log(wwwInteract.downloadHandler.text);
            }
        }
    }
}
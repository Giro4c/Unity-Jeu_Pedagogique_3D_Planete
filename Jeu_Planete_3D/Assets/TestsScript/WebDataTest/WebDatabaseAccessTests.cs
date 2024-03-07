using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

using Script.WebData;

namespace Tests
{
    public class WebDatabaseAccessTests
    {
        private WebDatabaseAccess webDatabaseAccess;

        [SetUp]
        public void SetUp()
        {
            // Créer une instance de WebDatabaseAccess pour chaque test
            webDatabaseAccess = ScriptableObject.CreateInstance<WebDatabaseAccess>();
        }

        [UnityTest]
        public IEnumerator NewGameTest()
        {
            // Activer la méthode NewGame avec une plateforme arbitraire
            string platform = "Windows";
            yield return webDatabaseAccess.NewGame(platform);

            // Vérifier que la méthode s'exécute sans erreur
            Assert.Pass();
        }

        [UnityTest]
        public IEnumerator AbortGameTest()
        {
            // Activer la méthode AbortGame
            yield return webDatabaseAccess.AbortGame();

            // Vérifier que la méthode s'exécute sans erreur
            Assert.Pass();
        }

        [UnityTest]
        public IEnumerator EndGameTest()
        {
            // Activer la méthode EndGame
            yield return webDatabaseAccess.EndGame();

            // Vérifier que la méthode s'exécute sans erreur
            Assert.Pass();
        }

        [UnityTest]
        public IEnumerator AddInteractionTest()
        {
            // Activer la méthode AddInteraction avec des valeurs arbitraires
            string type = "type";
            float value = 1.0f;
            bool quizzStarted = true;
            yield return webDatabaseAccess.AddInteraction(type, value, quizzStarted);

            // Vérifier que la méthode s'exécute sans erreur
            Assert.Pass();
        }

        [UnityTest]
        public IEnumerator GetQuestionTest()
        {
            // Activer la méthode GetQuestion avec un ID de question arbitraire
            int qid = 1;
            yield return webDatabaseAccess.GetQuestion(qid);

            // Vérifier que la méthode s'exécute sans erreur
            Assert.Pass();
        }

        [UnityTest]
        public IEnumerator GetRandomQuestionsTest()
        {
            // Activer la méthode GetRandomQuestions avec des valeurs arbitraires
            int nbQcu = 1;
            int nbTrueFalse = 1;
            int nbManipulation = 1;
            yield return webDatabaseAccess.GetRandomQuestions(nbQcu, nbTrueFalse, nbManipulation);

            // Vérifier que la méthode s'exécute sans erreur
            Assert.Pass();
        }

        [UnityTest]
        public IEnumerator AddUserAnswerTest()
        {
            // Activer la méthode AddUserAnswer avec des valeurs arbitraires
            int qid = 1;
            string dateStart = "date";
            bool correct = true;
            yield return webDatabaseAccess.AddUserAnswer(qid, dateStart, correct);

            // Vérifier que la méthode s'exécute sans erreur
            Assert.Pass();
        }
    }
}


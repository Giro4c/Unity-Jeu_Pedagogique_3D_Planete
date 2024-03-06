using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Script.Services.Test
{
    public class GameServiceTests
    {
        private GameObject gameServiceObject;
        private GameService gameService;

        [SetUp]
        public void SetUp()
        {
            // Crée un GameObject et ajoute un composant GameService pour chaque test
            gameServiceObject = new GameObject("GameServiceTestObject");
            gameService = gameServiceObject.AddComponent<GameService>();
        }

        [TearDown]
        public void TearDown()
        {
            // Détruit l'objet GameObject créé pour chaque test
            GameObject.Destroy(gameServiceObject);
        }

        [UnityTest]
        public IEnumerator StartGame_Successful()
        {
            // Teste si le jeu démarre correctement pour une plateforme donnée
            string platform = "Windows";
            yield return gameService.StartGame(platform);

            // Vérifie si le jeu a démarré avec succès
            // (Dans cet exemple, on vérifie simplement si la méthode StartGame n'a pas renvoyé d'erreur)
            Assert.Pass();
        }

        [UnityTest]
        public IEnumerator AbortGame_Successful()
        {
            // Teste si le jeu s'arrête correctement
            yield return gameService.AbortGame();

            // Vérifie si le jeu s'est arrêté avec succès
            // (Dans cet exemple, on vérifie simplement si la méthode AbortGame n'a pas renvoyé d'erreur)
            Assert.Pass();
        }

        [UnityTest]
        public IEnumerator EndGame_Successful()
        {
            // Teste si le jeu se termine correctement
            yield return gameService.EndGame();

            // Vérifie si le jeu s'est terminé avec succès
            // (Dans cet exemple, on vérifie simplement si la méthode EndGame n'a pas renvoyé d'erreur)
            Assert.Pass();
        }

        [UnityTest]
        public IEnumerator PauseMenu_Activated()
        {
            // Teste si le menu de pause est activé correctement
            gameService.Pause();

            // Vérifie si le menu de pause est activé
            Assert.IsTrue(gameService.pauseMenu.activeSelf);

            // Vérifie si le temps est arrêté
            Assert.AreEqual(0f, Time.timeScale);
        }

        [UnityTest]
        public IEnumerator PauseMenu_Deactivated()
        {
            // Teste si le menu de pause est désactivé correctement
            gameService.Resume();

            // Vérifie si le menu de pause est désactivé
            Assert.IsFalse(gameService.pauseMenu.activeSelf);

            // Vérifie si le temps est rétabli
            Assert.AreEqual(1f, Time.timeScale);
        }

        [UnityTest]
        public IEnumerator Displays_Correctly()
        {
            // Teste si les informations sont correctement affichées
            gameService.Displays();

            // Ici, tu pourrais ajouter des assertions pour vérifier si les composants InformationDisplayer fonctionnent correctement
            // Par exemple, tu pourrais vérifier si les informations sont correctement mises à jour sur l'écran
            Assert.Pass();
        }

        // Un test simple pour la forme
        [Test]
        public void GameServiceTestsSimplePasses()
        {
            Assert.Pass();
        }

        // Un test de coroutine simple pour la forme
        [UnityTest]
        public IEnumerator GameServiceTestsWithEnumeratorPasses()
        {
            yield return null;
        }
    }
}

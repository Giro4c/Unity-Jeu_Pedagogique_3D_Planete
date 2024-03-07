using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Script.Services.Tests
{
    public class GameServiceTests
    {
        private GameService gameService;

        [SetUp]
        public void SetUp()
        {
            // Créer une instance de GameService pour chaque test
            GameObject gameObject = new GameObject();
            gameService = gameObject.AddComponent<GameService>();
        }

        [TearDown]
        public void TearDown()
        {
            // Détruire l'instance de GameService après chaque test
            Object.Destroy(gameService.gameObject);
        }

        [UnityTest]
        public IEnumerator StartGameTest()
        {
            // Activer la méthode StartGame et vérifier qu'elle renvoie bien une coroutine
            IEnumerator coroutine = gameService.StartGame("Windows");
            yield return null; // Attendre une frame simulée pour que la coroutine soit exécutée
            Assert.IsNotNull(coroutine);
        }

        [UnityTest]
        public IEnumerator AbortGameTest()
        {
            // Activer la méthode AbortGame et vérifier qu'elle renvoie bien une coroutine
            IEnumerator coroutine = gameService.AbortGame();
            yield return null; // Attendre une frame simulée pour que la coroutine soit exécutée
            Assert.IsNotNull(coroutine);
        }

        [UnityTest]
        public IEnumerator EndGameTest()
        {
            // Activer la méthode EndGame et vérifier qu'elle renvoie bien une coroutine
            IEnumerator coroutine = gameService.EndGame();
            yield return null; // Attendre une frame simulée pour que la coroutine soit exécutée
            Assert.IsNotNull(coroutine);
        }

        /*
        [Test]
        public void PauseTest()
        {
            // Activer la méthode Pause et vérifier que le menu de pause est activé et que le temps est mis en pause
            gameService.Pause();
            Assert.IsTrue(gameService.pauseMenu.activeSelf);
            Assert.AreEqual(0f, Time.timeScale);
        }

        [Test]
        public void ResumeTest()
        {
            // Activer la méthode Resume et vérifier que le menu de pause est désactivé et que le temps reprend
            gameService.Resume();
            Assert.IsFalse(gameService.pauseMenu.activeSelf);
            Assert.AreEqual(1f, Time.timeScale);
        }
        */
    }
}


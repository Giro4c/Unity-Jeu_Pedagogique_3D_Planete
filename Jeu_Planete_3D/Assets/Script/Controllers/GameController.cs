using System;
using System.Collections;
using Script.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Controllers
{
    public class GameController: MonoBehaviour
    {

        private GameService _gameService;
        private string sceneHomeName;
        private string sceneGameName;
        private string platform;

        private void Start()
        {
            DisplaysAction();
        }

        private void Update()
        {
            DisplaysAction();
        }

        public IEnumerator StartGame()
        {
            yield return StartCoroutine(_gameService.StartGame(platform));
            SceneManager.LoadScene(sceneGameName);
        }

        public IEnumerator EndGame()
        {
            yield return StartCoroutine(_gameService.EndGame());
            SceneManager.LoadScene(sceneHomeName);
        }

        public IEnumerator HomeAction()
        {
            _gameService.Resume();
            yield return StartCoroutine(_gameService.AbortGame());
            SceneManager.LoadScene(sceneHomeName);
        }

        public void Pause()
        {
            _gameService.Pause();
        }

        public void Resume()
        {
            _gameService.Resume();
        }

        public void DisplaysAction()
        {
            _gameService.Displays();
        }
        
    }
}
using System;
using System.Collections;
using Script.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Controllers
{
    public class GameController: MonoBehaviour
    {

        [SerializeField] private GameService _gameService;
        [SerializeField] private string sceneHomeName;
        [SerializeField] private string sceneGameName;
        [SerializeField] private string platform;

        private void Start()
        {
            DisplaysAction();
        }

        private void Update()
        {
            DisplaysAction();
        }

        public IEnumerator StartGameAction()
        {
            yield return StartCoroutine(_gameService.StartGame(platform));
            StartCoroutine(_gameService.Load(sceneGameName));
        }

        public void StartGame()
        {
            StartCoroutine(StartGameAction());
        }

        public IEnumerator EndGameAction()
        {
            yield return StartCoroutine(_gameService.EndGame());
            SceneManager.LoadScene(sceneHomeName);
        }
        
        public void EndGame()
        {
            StartCoroutine(EndGameAction());
        }

        public IEnumerator HomeAction()
        {
            _gameService.Resume();
            yield return StartCoroutine(_gameService.AbortGame());
            SceneManager.LoadScene(sceneHomeName);
        }
        
        public void Home()
        {
            StartCoroutine(HomeAction());
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
using System.Collections;
using UnityEngine;

namespace Script.Services
{
    public class GameService
    {

        private WebDatabaseAccessInterface linkWeb;
        private GameObject pauseMenu;
        private InformationDisplayer[] displayers;

        public IEnumerator StartGame(string platform)
        {
            return linkWeb.NewGame(platform);
        }
        
        public IEnumerator AbortGame()
        {
            return linkWeb.AbortGame();
        }
        
        public IEnumerator EndGame()
        {
            return linkWeb.EndGame();
        }

        public void Pause()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

        public void Resume()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }

        public void Displays()
        {
            foreach (InformationDisplayer displayed in displayers)
            {
                displayed.Display();
            }
        }

    }
}
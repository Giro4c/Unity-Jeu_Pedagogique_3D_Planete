using System.Collections;
using Script.WebData;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script.Services
{
    public class GameService : MonoBehaviour
    {

        [SerializeReference] private WebDatabaseAccess linkWeb;
        
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private Slider loadIndicator;
        [SerializeField] private InformationDisplayer[] displayers;

        public IEnumerator StartGame(string platform)
        {
            return linkWeb.NewGame(platform);
        }

        public IEnumerator Load(string sceneName)
        {
            AsyncOperation loader = SceneManager.LoadSceneAsync(sceneName);
            while (!loader.isDone)
            {
                float progress = Mathf.Clamp01(loader.progress / 0.9f);
                Debug.Log(progress);
                loadIndicator.value = progress;
                yield return null;
            }
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
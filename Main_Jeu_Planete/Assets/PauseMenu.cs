using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Home(string _sceneName)
    {
        // Afficher le temps écoulé dans la console
        Debug.Log("Temps écoulé : " + Timer.elapsedTimeStatic);

        SceneManager.LoadScene(_sceneName);
        Time.timeScale = 1;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
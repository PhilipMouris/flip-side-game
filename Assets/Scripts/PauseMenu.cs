using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;

    public void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        if (Manager.sound)
            Manager.PlayFast();
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
        if (Manager.sound)
            Manager.PlayFast();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

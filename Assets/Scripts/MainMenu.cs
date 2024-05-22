using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool firstRun = true;
    void Start()
    {
        if (firstRun)
        {
            firstRun = false;
            Manager.PlaySlow();
        }
    }

    public void StartGame()
    {
        if (Manager.sound)
            Manager.PlayFast();
        SceneManager.LoadScene("SampleScene");
    }

    public void SetOptions()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

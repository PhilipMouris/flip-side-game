using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("MuteButton").GetComponentInChildren<Text>().text = Manager.sound ? "MUTE" : "UNMUTE";
    }
    public void Mute()
    {
        Manager.sound = !Manager.sound;
        if (Manager.sound)
        {
            Manager.PlaySlow();
            GameObject.Find("MuteButton").GetComponentInChildren<Text>().text = "MUTE";
        }
        else
        {
            Manager.StopAll();
            GameObject.Find("MuteButton").GetComponentInChildren<Text>().text = "UNMUTE";
        }
    }

    public void HowTo()
    {
        SceneManager.LoadScene("HowTo");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}

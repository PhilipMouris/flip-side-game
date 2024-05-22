using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtons : MonoBehaviour
{
    public void Camera()
    {
        if (GameObject.Find("Main Camera").GetComponent<CameraSwitch>().sideView)
            GameObject.Find("Main Camera").GetComponent<CameraSwitch>().toggleForwardView();
        else
            GameObject.Find("Main Camera").GetComponent<CameraSwitch>().toggleSideView();
        GameObject.Find("Main Camera").GetComponent<CameraSwitch>().sideView = !GameObject.Find("Main Camera").GetComponent<CameraSwitch>().sideView;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        GameObject.Find("Sphere").GetComponent<SphereControl>().pausePanel.SetActive(true);
        if (Manager.sound)
            Manager.PlaySlow();
    }

    public void Flip()
    {
        if (Manager.sound)
            GameObject.Find("Sphere").GetComponent<SphereControl>().switchPlatformSound.Play();
        if (GameObject.Find("Sphere").transform.position.y == 0.46f)
            GameObject.Find("Sphere").transform.position = new Vector3(GameObject.Find("Sphere").transform.position.x, 6.17f, GameObject.Find("Main Camera").GetComponent<CameraSwitch>().sideView ? -36.66f : -34.66f);
        else
            GameObject.Find("Sphere").transform.position = new Vector3(GameObject.Find("Sphere").transform.position.x, 0.46f, -36.66f);
    }
}

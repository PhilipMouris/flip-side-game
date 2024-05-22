using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControl : MonoBehaviour
{
    public int color = 2;
    public GameObject pausePanel;
    public GameObject overPanel;
    public AudioSource switchPlatformSound;
    public AudioSource switchColorSound;
    public AudioSource orbSound;
    public AudioSource increaseScoreSound;
    public AudioSource decreaseScoreSound;
    public AudioSource obstacleSound;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeColor", 15.0f, 15.0f);
    }

    void ChangeColor()
    {
        if (Manager.sound)
            switchColorSound.Play();
        System.Random rnd = new System.Random();
        int randomColor = rnd.Next(1, 4);
        while (randomColor == color)
            randomColor = rnd.Next(1, 4);
        color = randomColor;
        switch (randomColor)
        {
            case 1:
                gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                break;
            case 2:
                gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                break;
            case 3:
                gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey("left") || Input.GetKey("a")) && transform.position.x >= -5.8f)
        {
            transform.position = new Vector3(transform.position.x - (10f * Time.deltaTime), transform.position.y, transform.position.z);
        }

        if ((Input.GetKey("right") || Input.GetKey("d")) && transform.position.x <= 2.8f)
        {
            transform.position = new Vector3(transform.position.x + (10f * Time.deltaTime), transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown("space"))
        {
            if (Manager.sound)
                switchPlatformSound.Play();
            if (transform.position.y == 0.46f)
                transform.position = new Vector3(transform.position.x, 6.17f, GameObject.Find("Main Camera").GetComponent<CameraSwitch>().sideView ? -36.66f : -34.66f);
            else
                transform.position = new Vector3(transform.position.x, 0.46f, -36.66f);
        }

        if (Input.GetKeyDown("r"))
            ChangeColor();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pausePanel.SetActive(true);
                if (Manager.sound)
                    Manager.PlaySlow();
            }
            else
            {
                Time.timeScale = 1;
                pausePanel.SetActive(false);
                if (Manager.sound)
                    Manager.PlayFast();
            }
        }


        if (Application.platform == RuntimePlatform.Android && Time.timeScale == 1)
        {
            if ((Input.acceleration.x < 0f && transform.position.x >= -5.8f) || (Input.acceleration.x > 0f && transform.position.x <= 2.8f))
                transform.Translate(Input.acceleration.x * 0.5f, 0f, 0f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if (other.gameObject.name.Contains("Orb"))
        {
            if (Manager.sound)
                orbSound.Play();
            if (GameObject.Find("HP").GetComponent<HP>().hp < 3)
                GameObject.Find("HP").GetComponent<HP>().hp += 1;
        }
        if (other.gameObject.name.Contains("Obstacle"))
        {
            if (Manager.sound)
                obstacleSound.Play();
            if (GameObject.Find("HP").GetComponent<HP>().hp > 0)
                GameObject.Find("HP").GetComponent<HP>().hp -= 1;
            else
            {
                Time.timeScale = 0;
                overPanel.SetActive(true);
                if (Manager.sound)
                    Manager.PlaySlow();
            }
        }
        if (other.gameObject.name.Contains("Coin"))
            if (transform.position.y == 0.46f)
                if (gameObject.GetComponent<MeshRenderer>().material.color == other.gameObject.GetComponent<MeshRenderer>().material.color)
                {
                    if (Manager.sound)
                        increaseScoreSound.Play();
                    GameObject.Find("Score").GetComponent<Score>().score += 10;
                }
                else
                {
                    if (Manager.sound)
                        decreaseScoreSound.Play();
                    if (GameObject.Find("Score").GetComponent<Score>().score > 0)
                        GameObject.Find("Score").GetComponent<Score>().score -= 5;
                }
            else
                if (gameObject.GetComponent<MeshRenderer>().material.color == other.gameObject.GetComponent<MeshRenderer>().material.color)
                {
                    if (Manager.sound)
                        decreaseScoreSound.Play();
                    if (GameObject.Find("Score").GetComponent<Score>().score > 0)
                            GameObject.Find("Score").GetComponent<Score>().score -= 5;
                }
                else
                {
                    if (Manager.sound)
                        increaseScoreSound.Play();
                    GameObject.Find("Score").GetComponent<Score>().score += 10;
                }
    }
}

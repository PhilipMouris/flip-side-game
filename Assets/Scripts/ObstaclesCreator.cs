using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesCreator : MonoBehaviour
{
    public GameObject smallObstaclePrefab;
    public GameObject mediumObstaclePrefab;
    public GameObject largeObstaclePrefab;
    public GameObject coinPrefab;
    public GameObject orbPrefab;
    public bool up = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateObstacle", 0.0f, 2.0f);
        InvokeRepeating("CreateCoin", 0.0f, 1.0f);
        InvokeRepeating("CreateOrb", 5.7f, 5.7f);
    }

    void CreateObstacle()
    {
        up = !up;
        System.Random rnd = new System.Random();
        switch (rnd.Next(1, 4))
        {
            case 1:
                float horizontalPosition = 0f;
                switch (rnd.Next(1, 4))
                {
                    case 1:
                        horizontalPosition = -4.3f;
                        break;
                    case 2:
                        horizontalPosition = -1.4f;
                        break;
                    case 3:
                        horizontalPosition = 1.6f;
                        break;
                }
                Instantiate(smallObstaclePrefab, new Vector3(horizontalPosition, up ? 0.7f : 6.17f, this.transform.position.z), Quaternion.identity);
                break;
            case 2:
                Instantiate(mediumObstaclePrefab, new Vector3(rnd.Next(1, 3) % 2 == 0 ? -2.9f : 0.1f, up ? 0.7f : 6.17f, this.transform.position.z), Quaternion.identity);
                break;
            case 3:
                Instantiate(largeObstaclePrefab, new Vector3(-1.4f, up ? 0.7f : 6.17f, this.transform.position.z), Quaternion.identity);
                break;
        }
    }

    void CreateCoin()
    {
        up = !up;
        System.Random rnd = new System.Random();
        float horizontalPosition = 0f;
        float verticalPosition = up ? 0.7f : 6.0f;
        switch (rnd.Next(1, 4))
        {
            case 1:
                horizontalPosition = -4.3f;
                break;
            case 2:
                horizontalPosition = -1.4f;
                break;
            case 3:
                horizontalPosition = 1.6f;
                break;
        }
        GameObject coin = Instantiate(coinPrefab, new Vector3(horizontalPosition, verticalPosition, this.transform.position.z), Quaternion.identity);
        coin.transform.Rotate(-90f, 0, 0);
        switch (rnd.Next(1, 4))
        {
            case 1:
                coin.GetComponent<MeshRenderer>().material.color = Color.blue;
                break;
            case 2:
                coin.GetComponent<MeshRenderer>().material.color = Color.red;
                break;
            case 3:
                coin.GetComponent<MeshRenderer>().material.color = Color.green;
                break;
        }
    }

    void CreateOrb()
    {
        up = !up;
        System.Random rnd = new System.Random();
        float horizontalPosition = 0f;
        float verticalPosition = up ? 0.7f : 6.0f;
        switch (rnd.Next(1, 4))
        {
            case 1:
                horizontalPosition = -4.3f;
                break;
            case 2:
                horizontalPosition = -1.4f;
                break;
            case 3:
                horizontalPosition = 1.6f;
                break;
        }
        Instantiate(orbPrefab, new Vector3(horizontalPosition, verticalPosition, this.transform.position.z), Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int speed = (GameObject.Find("Score").GetComponent<Score>().score / 50) + 1;
        if (transform.position.z < -50)
        {
            if (gameObject.name.EndsWith("(Clone)"))
                Destroy(gameObject);
        }
        else
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (20f * speed * Time.deltaTime));
    }
}

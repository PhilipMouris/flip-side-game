using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public bool sideView = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            if (sideView)
                toggleForwardView();
            else
                toggleSideView();
            sideView = !sideView;
        }
    }

    public void toggleForwardView()
    {
        transform.position = new Vector3(-1.348452f, 4.134627f, -42.23722f);
        transform.rotation = Quaternion.Euler(9.694f, -0.686f, -0.006f);
    }

    public void toggleSideView()
    {
        transform.position = new Vector3(8.101387f, 2.578193f, -30.468f);
        transform.rotation = Quaternion.Euler(-4.744f, -90.069f, -0.005f);
    }
}

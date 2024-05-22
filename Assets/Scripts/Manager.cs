using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static bool sound = true;
    //public static AudioSource fastTrack;
    //public static AudioSource slowTrack;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayFast()
    {
        GameObject.Find("SlowTrack").GetComponent<AudioSource>().Stop();
        GameObject.Find("FastTrack").GetComponent<AudioSource>().Play();
    }

    public static void PlaySlow()
    {
        GameObject.Find("FastTrack").GetComponent<AudioSource>().Stop();
        GameObject.Find("SlowTrack").GetComponent<AudioSource>().Play();
    }

    public static void StopAll()
    {
        GameObject.Find("FastTrack").GetComponent<AudioSource>().Stop();
        GameObject.Find("SlowTrack").GetComponent<AudioSource>().Stop();
    }
}

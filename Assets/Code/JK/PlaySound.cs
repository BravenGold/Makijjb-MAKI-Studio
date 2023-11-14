



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    AudioSource aud;

    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    public void play_sound()
    {
        aud.Play();
    }

}
/*
    
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource sound1;
    public AudioSource sound2;

    void Start()
    {
        // Get the AudioSource components attached to the GameObject
        if (transform.childCount >= 2)
        {
            sound1 = transform.GetChild(0).GetComponent<AudioSource>();
            sound2 = transform.GetChild(1).GetComponent<AudioSource>();
        }
        else
        {
            Debug.LogError("Not enough child objects on the GameObject to get AudioSource components.");
        }
    }


    void Update()
    {
        // You can add update logic here if needed
    }

    public void PlaySound1()
    {
        if (sound1 != null && !sound1.isPlaying)
        {
            sound1.Play();
        }
    }

    public void PlaySound2()
    {
        if (sound2 != null && !sound2.isPlaying)
        {
            sound2.Play();
        }
    }
}


*/
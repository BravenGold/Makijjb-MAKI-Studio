using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource soundEffectsSource;

    [Header("---------- Audio Clips ----------")]
    public AudioClip background;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!musicSource.isPlaying)
        {
            musicSource.clip = background;
            musicSource.Play();
        }
    }
}

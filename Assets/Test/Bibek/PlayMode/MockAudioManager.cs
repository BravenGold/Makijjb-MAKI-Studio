using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockAudioManager : IAudioManager
{
    // Mock volumes, initially set to a default of 1.0f (max volume)
    private float mockSoundVolume = 1.0f;
    private float mockMusicVolume = 1.0f;

    public float MockSoundVolume => mockSoundVolume;
    public float MockMusicVolume => mockMusicVolume;

    public void ChangeSoundVolume(float change)
    {
        mockSoundVolume += change;

        // Ensure the volume stays within the bounds [0, 1]
        mockSoundVolume = Mathf.Clamp(mockSoundVolume, 0f, 1f);
    }

    public void ChangeMusicVolume(float change)
    {
        mockMusicVolume += change;

        // Ensure the volume stays within the bounds [0, 1]
        mockMusicVolume = Mathf.Clamp(mockMusicVolume, 0f, 1f);
    }
}

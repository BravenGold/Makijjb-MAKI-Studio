using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SoundIncreaseTest
{
    private UIManager uiManager;
    private AudioManager audioManager;

    [UnityTest]
    public IEnumerator TestVolumeBoundaries()
    {
        // Set to Max
        while (PlayerPrefs.GetFloat("soundVolume", 1) < 1.0f)
        {
            uiManager.SoundVolume();
            yield return null;
        }
        Assert.AreEqual(1.0f, PlayerPrefs.GetFloat("soundVolume", 1));

        // Set to Min
        while (PlayerPrefs.GetFloat("soundVolume", 1) > 0.0f)
        {
            uiManager.SoundVolume();
            yield return null;
        }
        Assert.AreEqual(0.0f, PlayerPrefs.GetFloat("soundVolume", 1));

        // Increase when at Max (Should remain at Max)
        uiManager.SoundVolume();
        Assert.AreEqual(1.0f, PlayerPrefs.GetFloat("soundVolume", 1));

        // Decrease when at Min (Should remain at Min)
        uiManager.SoundVolume();
        Assert.AreEqual(0.0f, PlayerPrefs.GetFloat("soundVolume", 1));

        // Rapid Change
        for (int i = 0; i < 100; i++)
        {
            uiManager.SoundVolume();
            yield return null;
        }

        // Potentially check that the value is what you expect after 100 changes.
    }

}

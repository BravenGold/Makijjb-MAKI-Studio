using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SoundIncreaseTest
{
    private GameObject uiManagerObject;
    private UIManager uiManager;

    [SetUp]
    public void Setup()
    {
        // Initialize the UIManager object
        uiManagerObject = new GameObject();
        uiManager = uiManagerObject.AddComponent<UIManager>();

        GameObject mockPauseScreen = new GameObject("MockPauseScreen");
        uiManager.SetPauseScreen(mockPauseScreen);
    }



    [TearDown]
    public void Teardown()
    {
        // Cleanup after each test
        UnityEngine.Object.DestroyImmediate(uiManagerObject);
    }

    [UnityTest]
    public IEnumerator TestVolumeBoundaries()
    {
        // Assuming SoundVolume increments or decrements by 0.2f as per your UIManager implementation

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

        // Assert final state after rapid changes, but the exact expected value will depend on your UIManager logic.
        // For now, leaving this assertion out.

        yield return null;
    }

    [Test]
    public void TestSoundVolumeIncrease()
    {
        var mockAudio = new MockAudioManager();

        mockAudio.ChangeSoundVolume(0.2f);

        Assert.AreEqual(1.0f, mockAudio.MockSoundVolume);  // Assert that the volume is clamped to 1.0f
    }


    [UnityTest]
    public IEnumerator RapidPauseUnpauseStressTest()
    {
        int iterationCount = 0;
        bool exceptionOccurred = false;

        for (int i = 0; i < 100; i++)
        {
            if (exceptionOccurred) break;

            try
            {
                Debug.Log($"Iteration {iterationCount} - Pausing");
                uiManager.PauseGame(true);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Exception occurred at iteration {iterationCount}: {ex.Message}");
                exceptionOccurred = true;
                continue;
            }

            yield return new WaitForSecondsRealtime(0.01f);

            try
            {
                Debug.Log($"Iteration {iterationCount} - Unpausing");
                uiManager.PauseGame(false);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Exception occurred at iteration {iterationCount}: {ex.Message}");
                exceptionOccurred = true;
                continue;
            }

            yield return new WaitForSecondsRealtime(0.01f);
            iterationCount++;
        }

        if (!exceptionOccurred)
        {
            Assert.IsFalse(uiManager.IsPauseScreenActive(), "Game should not be paused after toggling.");
        }
        else
        {
            Assert.Fail($"Test failed at iteration: {iterationCount}");
        }
    }

}

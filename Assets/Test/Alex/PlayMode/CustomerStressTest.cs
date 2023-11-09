using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class CustomerStressTest
{
    private string sceneName = "Customer Bomb";
    private float minimumFrameRate = 30.0f; // Set your minimum acceptable frame rate
    private float testDuration = 30.0f; // Set the duration of the test in seconds

    [UnityTest]
    public IEnumerator CheckFrameRate()
    {
        SceneManager.LoadScene(sceneName);
        float timer = 0.0f;
        bool frameRateBelowMinimum = false;

        while (timer < testDuration)
        {
            if (1.0f / Time.unscaledDeltaTime < minimumFrameRate)
            {
                frameRateBelowMinimum = true;
                break;
            }

            timer += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        Assert.IsFalse(frameRateBelowMinimum, "Frame rate dropped below the acceptable minimum.");
    }
}

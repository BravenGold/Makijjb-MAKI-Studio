using UnityEngine;

public class FrameRateLimiter : MonoBehaviour
{
    public int targetFrameRate = 60;
    private TestFoodSpawner foodSpawner; // Reference to the TestFoodSpawner script

    private void Start()
    {
        Application.targetFrameRate = targetFrameRate;
        
        // Find the TestFoodSpawner script in the scene
        foodSpawner = FindObjectOfType<TestFoodSpawner>();
    }

    private void Update()
    {
        if (1.0f / Time.deltaTime < 10.0f)
        {
            int trackerValue = foodSpawner.tracker;
            Debug.Log("Frame rate got bellow" + targetFrameRate);
            Debug.Log("Tracker Value: " + trackerValue);
            Time.timeScale = 0.0f; // Pause the game
        }

    }
}

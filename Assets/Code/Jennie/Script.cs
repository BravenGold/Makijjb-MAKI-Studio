using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    public static int levelIndex;
    // Start is called before the first frame update

    void Start()
    {
        levelIndex = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            NextLevel();
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Update is called once per frame
    void NextLevel()
    {
        Debug.Log(levelIndex);
        levelIndex++;
        Debug.Log(levelIndex);
        SceneManager.LoadScene(levelIndex);
    }
}

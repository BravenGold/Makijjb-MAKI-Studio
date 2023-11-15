using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("UI Screens")]
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject mainMenuScreen; // Serialized field for the main menu screen

    private GameManager gameManager; // Reference to GameManager

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>(); // Find the GameManager in the scene

        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
            return;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseGame();
        }
    }

    public void SetPauseScreenActive(bool active)
    {
        if (pauseScreen != null)
        {
            Debug.Log($"Setting pause screen active: {active}");
            pauseScreen.SetActive(active);
        }
        else
        {
            Debug.LogError("PauseScreen is not assigned in UIManager.");
        }
    }

    public void SetMainMenuActive(bool active)
    {
        if (mainMenuScreen != null)
        {
            Debug.Log($"Setting main menu screen active: {active}");
            mainMenuScreen.SetActive(active);
        }
        else
        {
            Debug.LogError("MainMenuScreen is not assigned in UIManager.");
        }
    }


    public void TogglePauseGame()
    {
        if (gameManager.CurrentState is PauseMenuState)
        {
            gameManager.ChangeState(new InGameState(this, gameManager));
        }
        else
        {
            gameManager.ChangeState(new PauseMenuState(this, gameManager));
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (gameManager != null)
        {
            gameManager.ChangeState(new InGameState(this, gameManager));
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0); // Load the main menu scene
        if (gameManager != null)
        {
            gameManager.ChangeState(new MainMenuState(this, gameManager));
        }
    }

    public void Quit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Quit the play mode in editor
#endif
    }

    public void SoundVolume()
    {
        AudioManager.instance.ChangeSoundVolume(0.2f);
    }

    public void MusicVolume()
    {
        AudioManager.instance.ChangeMusicVolume(0.2f);
    }

    // Additional UI-related methods if needed
}

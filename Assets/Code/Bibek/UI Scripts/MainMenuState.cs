using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState : IGameState
{
    private UIManager uiManager; // Reference to your UIManager script
    private GameManager gameManager; // Reference to GameManager for state transitions

    public MainMenuState(UIManager uiManager, GameManager gameManager)
    {
        this.uiManager = uiManager;
        this.gameManager = gameManager;
    }

    public void EnterState()
    {
        // Activate the main menu UI
        if (uiManager != null)
        {
            uiManager.SetMainMenuActive(true); // Assuming a method to handle main menu UI
        }

        // Additional setup for the main menu, such as initializing settings
        // or resetting selections and animations
    }

    public void UpdateState()
    {
        // Handle any updates specific to the main menu
        // This might include handling animations or checking for specific user inputs
    }

    public void ExitState()
    {
        // Cleanup the main menu UI
        if (uiManager != null)
        {
            uiManager.SetMainMenuActive(false); // Assuming a method to disable main menu UI
        }

        // Additional cleanup actions for leaving the main menu
    }

    // Methods for menu actions
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1); // Load the game scene
        // Consider changing state to InGameState after the scene is loaded
    }

    public void QuitGame()
    {
        Application.Quit();
        // Add additional quit logic if needed
    }
}

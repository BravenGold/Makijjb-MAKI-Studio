using UnityEngine;

public class PauseMenuState : IGameState
{
    private UIManager uiManager; // Reference to your UIManager script
    private GameManager gameManager; // Reference to GameManager for state transitions

    public PauseMenuState(UIManager uiManager, GameManager gameManager)
    {
        this.uiManager = uiManager;
        this.gameManager = gameManager;
    }

    public void EnterState()
    {
        // Enable the pause menu UI
        if (uiManager != null)
        {
            uiManager.SetPauseScreenActive(true);
        }

        // Pause game-specific processes
        Time.timeScale = 0;
    }

    public void UpdateState()
    {
        // Handle updates specific to the pause menu (e.g., input for menu options)
    }

    public void ExitState()
    {
        // Clean up the pause menu UI
        if (uiManager != null)
        {
            uiManager.SetPauseScreenActive(false);
        }

        // Resume game-specific processes
        Time.timeScale = 1;
    }

    // Method to resume the game
    public void ResumeGame()
    {
        if (gameManager != null)
        {
            gameManager.ChangeState(new InGameState(uiManager, gameManager));
        }
    }

    // Method to quit to the main menu
    public void QuitToMainMenu()
    {
        if (gameManager != null)
        {
            gameManager.ChangeState(new MainMenuState(uiManager, gameManager));
        }
    }
}

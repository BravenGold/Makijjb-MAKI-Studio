using UnityEngine;

public class InGameState : IGameState
{
    private UIManager uiManager; // Reference to UIManager for UI-related activities
    private GameManager gameManager; // Reference to GameManager for state transitions

    public InGameState(UIManager uiManager, GameManager gameManager)
    {
        this.uiManager = uiManager;
        this.gameManager = gameManager;
    }

    public void EnterState()
    {
        // Resume the game's time scale if coming from a paused state
        Time.timeScale = 1;

        // Hide pause menu UI if it's active
        if (uiManager != null)
        {
            uiManager.SetPauseScreenActive(false);
        }

        // Activate or initialize gameplay-specific UI elements
        // For example, enabling HUD, score counters, etc.

        // Enable or initialize other gameplay elements
        // This could involve enabling player controls, restarting game timers, etc.
        // Add your specific game logic here
    }

    public void UpdateState()
    {
        // Update gameplay logic each frame
        // This could include player input handling, game object updates, etc.
        // Add your specific game update logic here
    }

    public void ExitState()
    {
        // Actions to perform when exiting the in-game state
        // This might include pausing game mechanics or saving progress
        // For example, disabling player controls if they aren't needed in the next state

        // Hide or deactivate gameplay-specific UI elements
        // For example, hiding HUD, pausing timers, etc.
    }

    // Add additional methods if needed for gameplay-specific actions
}

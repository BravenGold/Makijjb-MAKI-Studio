using UnityEngine;

public class GameManager : MonoBehaviour
{
    private IGameState currentState;
    private BaseMenu currentMenu; // Added to handle BaseMenu instances

    [SerializeField] private UIManager uiManager; // Serialized reference to UIManager

    public IGameState CurrentState => currentState;



    void Start()
    {
        if (uiManager == null)
        {
            Debug.LogError("UIManager not set in GameManager.");
            return;
        }

        // Initialize the main menu as the current menu
        currentMenu = new MainMenu(uiManager);
        currentMenu.OpenMenu(); // This should only open the main menu, not the pause menu


        // Temporary test for dynamic binding
        TestDynamicBinding();
    }


    void Update()
    {
        currentState?.UpdateState();
    }

    public void ChangeState(IGameState newState)
    {
        currentState?.ExitState();
        currentState = newState;
        currentState.EnterState();
    }

    // New method to change the current menu
    public void ChangeMenu(BaseMenu newMenu)
    {
        // Close the current menu before changing
        currentMenu?.CloseMenu();
        currentMenu = newMenu;
        currentMenu.OpenMenu();
    }

    // Method to open the current menu
    public void OpenCurrentMenu()
    {
        currentMenu.OpenMenu();
    }

    // Method to close the current menu
    public void CloseCurrentMenu()
    {
        currentMenu.CloseMenu();
    }


    private void TestDynamicBinding()
    {
        // Create instances of different menus
        BaseMenu mainMenu = new MainMenu(uiManager);
        // Assuming you have a PauseMenu class
        BaseMenu pauseMenu = new PauseMenu(uiManager);

        // Call methods on these instances
        mainMenu.OpenMenu(); // Should log "Opening Main Menu (MainMenu)"
        pauseMenu.OpenMenu(); // Should log "Opening Pause Menu (PauseMenu)", if you have this class
    }
}

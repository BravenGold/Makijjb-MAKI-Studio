using UnityEngine;
public class MainMenu : BaseMenu
{
    public MainMenu(UIManager uiManager) : base(uiManager) { }

    public override void OpenMenu()
    {
        base.OpenMenu(); // Call the base method if common logic is needed
        uiManager.SetMainMenuActive(true); // Activate the main menu UI
        Debug.Log("Main menu opened");
    }

    public override void CloseMenu()
    {
        base.CloseMenu(); // Call the base method if common logic is needed
        uiManager.SetMainMenuActive(false); // Deactivate the main menu UI
        Debug.Log("Main menu closed");
    }

    // Add other specific methods for the main menu as needed
}

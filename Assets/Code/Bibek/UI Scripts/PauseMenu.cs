using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : BaseMenu
{
    public PauseMenu(UIManager uiManager) : base(uiManager) { }

    public override void OpenMenu()
    {
        Debug.Log("Opening Pause Menu (PauseMenu)");
        // Additional logic for opening the pause menu
        uiManager.SetPauseScreenActive(false);
    }

    public override void CloseMenu()
    {
        Debug.Log("Closing Pause Menu (PauseMenu)");
        // Additional logic for closing the pause menu
        uiManager.SetPauseScreenActive(true);
    }
}

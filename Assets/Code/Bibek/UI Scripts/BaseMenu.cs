using UnityEngine;

public class BaseMenu
{
    protected UIManager uiManager;

    public BaseMenu(UIManager uiManager)
    {
        this.uiManager = uiManager;
    }

    public virtual void OpenMenu()  // Added 'void' return type
    {
        // Common logic to open a menu
        // This can include general animations, sound effects, etc.
        Debug.Log("Base menu opened");
    }

    public virtual void CloseMenu()
    {
        // Common logic to close a menu
        // This can include general animations, sound effects, etc.
        Debug.Log("Base menu closed");
    }

    // Additional common menu methods can be added here
}

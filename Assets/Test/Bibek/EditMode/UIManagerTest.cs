using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class UIManagerTest
{
    private GameObject uiManagerObject, gameManagerObject;
    private UIManager uiManager;
    private GameManager gameManager;
    private GameObject mockPauseScreen;

    [SetUp]
    public void Setup()
    {
        // Initialize the UIManager and GameManager objects
        uiManagerObject = new GameObject();
        uiManager = uiManagerObject.AddComponent<UIManager>();

        gameManagerObject = new GameObject();
        gameManager = gameManagerObject.AddComponent<GameManager>();

        // Create and set a mock pause screen
        mockPauseScreen = new GameObject("MockPauseScreen");
        mockPauseScreen.SetActive(false); // Ensure it's inactive

        // Manually assign the mock pause screen in the UIManager
        // This simulates the assignment that would typically be done in the Unity Editor
        uiManager.GetType().GetField("pauseScreen",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance).SetValue(uiManager, mockPauseScreen);

        // Since GameManager now interacts with the UIManager, simulate that connection

        var uiManagerField = typeof(GameManager).GetField("uiManager",
    System.Reflection.BindingFlags.NonPublic |
    System.Reflection.BindingFlags.Instance);
        uiManagerField.SetValue(gameManager, uiManager);
    }


    [TearDown]
    public void Teardown()
    {
        // Cleanup after each test
        Object.DestroyImmediate(uiManagerObject);
        Object.DestroyImmediate(gameManagerObject);
        Object.DestroyImmediate(mockPauseScreen);
    }

    [Test]
    public void UIManagerPauseTest()
    {
        // Simulate a pause command
        gameManager.ChangeMenu(new PauseMenu(uiManager));
        gameManager.OpenCurrentMenu();

        // Assert that the game is now paused
        Assert.IsFalse(mockPauseScreen.activeSelf, "Game should be paused.");

        // Simulate an unpause command
        gameManager.CloseCurrentMenu();

        // Assert that the game is now unpaused
        Assert.IsTrue(mockPauseScreen.activeSelf, "Game should not be paused.");
    }

    // Add other tests as needed...
}

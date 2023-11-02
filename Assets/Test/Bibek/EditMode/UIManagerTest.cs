using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class UIManagerTest
{
    private GameObject uiManagerObject;
    private UIManager uiManager;

    [SetUp]
    public void Setup()
    {
        // Initialize the UIManager object
        uiManagerObject = new GameObject();
        uiManager = uiManagerObject.AddComponent<UIManager>();
        GameObject mockPauseScreen = new GameObject("MockPauseScreen");
        mockPauseScreen.SetActive(false); // Ensure it's inactive

        uiManager.SetPauseScreen(mockPauseScreen);
    }

    [TearDown]
    public void Teardown()
    {
        // Cleanup after each test
        Object.DestroyImmediate(uiManagerObject);
    }

    [Test]
    public void UIManagerPauseTest()
    {
        // Ensure the game is not paused at the start
        Assert.IsFalse(uiManager.IsPauseScreenActive());

        // Simulate a pause command
        uiManager.PauseGame(true);

        // Assert that the game is now paused
        Assert.IsTrue(uiManager.IsPauseScreenActive());
    }

    // Add other tests as needed...
}

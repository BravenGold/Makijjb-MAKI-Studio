using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class SoundIncreaseTest
{
    private GameObject uiManagerObject, gameManagerObject;
    private UIManager uiManager;
    private GameManager gameManager;
    private GameObject mockPauseScreen;
    private GameObject mockMainMenuScreen; // Mock main menu screen

    [SetUp]
    public void Setup()
    {
        // Create and setup mock screens
        mockPauseScreen = new GameObject("MockPauseScreen");
        mockPauseScreen.SetActive(false);

        mockMainMenuScreen = new GameObject("MockMainMenuScreen"); // Create mock main menu screen
        mockMainMenuScreen.SetActive(false);

        // Initialize GameManager and UIManager objects
        gameManagerObject = new GameObject("GameManager");
        gameManager = gameManagerObject.AddComponent<GameManager>();

        uiManagerObject = new GameObject("UIManager");
        uiManager = uiManagerObject.AddComponent<UIManager>();

        // Manually assign the mock screens in the UIManager
        var pauseScreenField = typeof(UIManager).GetField("pauseScreen",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance);
        pauseScreenField.SetValue(uiManager, mockPauseScreen);

        var mainMenuScreenField = typeof(UIManager).GetField("mainMenuScreen",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance);
        mainMenuScreenField.SetValue(uiManager, mockMainMenuScreen);

        // Directly set the uiManager in GameManager
        var uiManagerField = typeof(GameManager).GetField("uiManager",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance);
        uiManagerField.SetValue(gameManager, uiManager);
    }


    [TearDown]
    public void Teardown()
    {
        // Cleanup after each test
        UnityEngine.Object.DestroyImmediate(mockPauseScreen);
        UnityEngine.Object.DestroyImmediate(uiManagerObject);
        UnityEngine.Object.DestroyImmediate(gameManagerObject);
    }

    [UnityTest]
    public IEnumerator RapidPauseUnpauseStressTest()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return PauseAndUnpause();
        }
    }

    private IEnumerator PauseAndUnpause()
    {
        // Attempt to pause
        gameManager.ChangeState(new PauseMenuState(uiManager, gameManager));
        yield return new WaitForSecondsRealtime(0.01f);
        Assert.IsTrue(mockPauseScreen.activeSelf, "Game should be paused.");

        // Attempt to unpause
        gameManager.ChangeState(new InGameState(uiManager, gameManager));
        yield return new WaitForSecondsRealtime(0.01f);
        Assert.IsFalse(mockPauseScreen.activeSelf, "Game should not be paused.");
    }

    /*[UnityTest]
        public IEnumerator TestVolumeBoundaries()
        {
            // Assuming SoundVolume increments or decrements by 0.2f as per your UIManager implementation

            // Set to Max
            while (PlayerPrefs.GetFloat("soundVolume", 1) < 1.0f)
            {
                uiManager.SoundVolume();
                yield return null;
            }
            Assert.AreEqual(1.0f, PlayerPrefs.GetFloat("soundVolume", 1));

            // Set to Min
            while (PlayerPrefs.GetFloat("soundVolume", 1) > 0.0f)
            {
                uiManager.SoundVolume();
                yield return null;
            }
            Assert.AreEqual(0.0f, PlayerPrefs.GetFloat("soundVolume", 1));

            // Increase when at Max (Should remain at Max)
            uiManager.SoundVolume();
            Assert.AreEqual(1.0f, PlayerPrefs.GetFloat("soundVolume", 1));

            // Decrease when at Min (Should remain at Min)
            uiManager.SoundVolume();
            Assert.AreEqual(0.0f, PlayerPrefs.GetFloat("soundVolume", 1));

            // Rapid Change
            for (int i = 0; i < 100; i++)
            {
                uiManager.SoundVolume();
                yield return null;
            }

            // Assert final state after rapid changes, but the exact expected value will depend on your UIManager logic.
            // For now, leaving this assertion out.

            yield return null;
        }
    */
    [Test]
    public void TestSoundVolumeIncrease()
    {
        var mockAudio = new MockAudioManager();

        mockAudio.ChangeSoundVolume(0.2f);

        Assert.AreEqual(1.0f, mockAudio.MockSoundVolume);  // Assert that the volume is clamped to 1.0f
    }


}

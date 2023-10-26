using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;

    [Header("Audio Manager")]
    [SerializeField] private IAudioManager audioManager; // Direct reference to AudioManager


    private void Awake()
    {
        if (pauseScreen != null)
        {
            pauseScreen.SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //If pause screen already active unpause and viceversa
            PauseGame(!pauseScreen.activeInHierarchy);
        }
    }

    public void SetPauseScreen(GameObject screen)
    {
        pauseScreen = screen;
        if (pauseScreen != null)
        {
            pauseScreen.SetActive(false);
        }
    }



    #region Pause
    //Restart level
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Main Menu
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Quit game/exit play mode if in Editor
    public void Quit()
    {
        Application.Quit(); //Quits the game (only works in build)

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //Exits play mode (will only be executed in the editor)
#endif
    }

    public bool IsPauseScreenActive()
    {
        return pauseScreen ? pauseScreen.activeInHierarchy : false;
    }
    public void PauseGame(bool status)
    {
        //If status == true pause | if status == false unpause
        pauseScreen.SetActive(status);

        //When pause status is true change timescale to 0 (time stops)
        //when it's false change it back to 1 (time goes by normally)
        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    public void SoundVolume()
    {
        AudioManager.instance.ChangeSoundVolume(0.2f);
    }
    public void MusicVolume()
    {
        AudioManager.instance.ChangeMusicVolume(0.2f);
    }
    #endregion
}
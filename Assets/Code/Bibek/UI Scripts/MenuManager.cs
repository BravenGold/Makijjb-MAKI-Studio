using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private RectTransform arrow;
    [SerializeField] private RectTransform[] buttons;
    [SerializeField] private AudioClip changeSound;
    [SerializeField] private AudioClip interactSound;

    private GameManager gameManager; // Reference to GameManager
    private int currentPosition;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>(); // Find the GameManager
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }

        ChangePosition(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            ChangePosition(-1);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            ChangePosition(1);

        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetButtonDown("Submit"))
            Interact();
    }

    public void ChangePosition(int change)
    {
        currentPosition += change;

        if (change != 0)
            AudioManager.instance.PlaySound(changeSound);

        if (currentPosition < 0)
            currentPosition = buttons.Length - 1;
        else if (currentPosition >= buttons.Length)
            currentPosition = 0;

        AssignPosition();
    }

    private void AssignPosition()
    {
        arrow.position = new Vector3(arrow.position.x, buttons[currentPosition].position.y);
    }

    private void Interact()
    {
        AudioManager.instance.PlaySound(interactSound);

        switch (currentPosition)
        {
            case 0:
                // Start game
                SceneManager.LoadScene(PlayerPrefs.GetInt("level", 1));
                break;
            case 1:
                // Open Settings
                break;
            case 2:
                // Open Credits
                break;
            case 3:
                // Quit Game
                Application.Quit();
                break;
        }
    }
}

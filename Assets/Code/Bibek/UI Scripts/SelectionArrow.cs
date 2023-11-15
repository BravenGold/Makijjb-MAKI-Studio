using UnityEngine;
using UnityEngine.UI;

public class SelectionArrow : MonoBehaviour
{
    [SerializeField] private RectTransform[] buttons;
    [SerializeField] private AudioClip changeSound;
    [SerializeField] private AudioClip interactSound;
    private RectTransform arrow;
    private int currentPosition;

    private void Awake()
    {
        arrow = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        currentPosition = 0;
        ChangePosition(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            ChangePosition(-1);
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            ChangePosition(1);

        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.E))
            Interact();
    }

    private void ChangePosition(int change)
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

        // Invoke the button's onClick event
        Button currentButton = buttons[currentPosition].GetComponent<Button>();
        if (currentButton != null && currentButton.interactable)
        {
            currentButton.onClick.Invoke();
        }
        else
        {
            Debug.LogWarning("Button component is missing or not interactable on the selected object.");
        }
    }
}

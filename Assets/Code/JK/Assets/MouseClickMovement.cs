using UnityEngine;

public class MouseClickMovement : MonoBehaviour
{
    public float speed = 2.0f;
    private Animator anim;
    private Vector2 destination;
    private bool isMoving = false;
    private SpriteRenderer spriteRenderer; // For flipping the sprite

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Make sure the GameObject has a SpriteRenderer component
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetDestination();
        }

        if (isMoving)
        {
            MoveCharacter();
            UpdateAnimation();
        }
        else
        {
            anim.SetBool("walkSide", false);
            //anim.SetBool("walkUpDown", false);
        }
    }

    private void SetDestination()
    {
        Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        destination = clickPosition;
        isMoving = true;
    }

    private void MoveCharacter()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, destination, step);

        if (Vector2.Distance(transform.position, destination) < 0.1f)
        {
            isMoving = false;
        }
    }

    private void UpdateAnimation()
    {
        Vector2 direction = (destination - new Vector2(transform.position.x, transform.position.y)).normalized;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            // Horizontal movement
            anim.SetBool("walkSide", true);
            //anim.SetBool("walkUpDown", false);

            // Flip the character sprite if moving left/right
            spriteRenderer.flipX = direction.x < 0;
        }
        else
        {
            // Vertical movement
            //anim.SetBool("walkUpDown", true);
            anim.SetBool("walkSide", false);
        }
    }
}

using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private LayerMask platoformsLayerMask;
    Rigidbody2D rb;
    CircleCollider2D circleCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if(IsGrounded() && Input.GetKeyDown(KeyCode.UpArrow))
        {
            float jumpVelocity = 40f;
            rb.velocity = Vector2.up * jumpVelocity;
        }
        HandleMovement();
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(circleCollider.bounds.center, circleCollider.bounds.size, 0f, Vector2.down, .1f,platoformsLayerMask);
        return raycast.collider != null;
    }

    private void HandleMovement()
    {
        float moveSpeed = 8f;
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }
}
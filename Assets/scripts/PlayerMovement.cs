using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public float slopeCheckDistance = 0.5f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool onSlope;
    private float slopeAngle;
    private Vector2 slopeNormal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, slopeCheckDistance, groundLayer);

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, 0).normalized;

        onSlope = IsOnSlope();

        // deals with slopes
        if (isGrounded && onSlope)
        {
            moveDirection = Vector2.Perpendicular(slopeNormal) * horizontalInput;
        }

        rb.linearVelocity = new Vector2(moveDirection.x * speed, rb.linearVelocity.y);

        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    bool IsOnSlope()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, slopeCheckDistance, groundLayer);

        if (hit)
        {
            slopeNormal = hit.normal;
            slopeAngle = Vector2.Angle(slopeNormal, Vector2.up);

            return Mathf.Approximately(slopeAngle, 45f);
        }
        return false;
    }
}

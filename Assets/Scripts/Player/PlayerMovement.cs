using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody2D rb;
    private PlayerAnimations anim;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        GroundCheck();
        ProcessInput();
        UpdateAnimations();
    }

    private void FixedUpdate() => Move();
    

    private void ProcessInput()
    {
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
            Jump();
    }

    private void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);

        if (moveHorizontal != 0)
        {
            playerSprite.flipX = moveHorizontal < 0;
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void UpdateAnimations()
    {
        anim.IsMoving = rb.velocity.x != 0;
        anim.IsGrounded = isGrounded;
        anim.IsFlying = rb.velocity.y < 0;
    }


}

using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float jumpForce = 5;

    [SerializeField] private Vector3 groundCheckPos;
    [SerializeField] private float checkRadius;

    private Rigidbody2D rb;

    private bool isGrounded = false;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        float horizontal = Input.GetAxis("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheckPos + transform.position, checkRadius) != null;

        if (isGrounded && Input.GetButton("Jump")) {
            rb.linearVelocityY = jumpForce;
        }

        rb.linearVelocityX = horizontal * moveSpeed;
    }
}

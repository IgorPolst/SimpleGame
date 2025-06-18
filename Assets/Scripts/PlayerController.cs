using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float jumpForce = 5;

    [SerializeField] private Vector3 groundCheckPos;
    [SerializeField] private float checkRadius;

    [SerializeField] private AudioSource jumpSound;

    private Rigidbody2D rb;
    private Animator animator;

    private bool isGrounded = false;

    [HideInInspector] public Vector3 activeCheckpoint = Vector3.zero;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        activeCheckpoint = transform.position;
    }

    private void Update() {
        float horizontal = Input.GetAxis("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheckPos + transform.position, checkRadius) != null;

        if (isGrounded && Input.GetButton("Jump")) {
            rb.linearVelocityY = jumpForce;
            jumpSound.Play();
        }

        rb.linearVelocityX = horizontal * moveSpeed;

        if (horizontal != 0) {
            animator.SetBool("isRunning", true);
        }
        else {
            animator.SetBool("isRunning", false);
        }
        animator.SetBool("isFalling", !isGrounded);

        if (horizontal > 0) {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontal < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}

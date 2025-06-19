using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private Transform[] patrolPath;

    [SerializeField] private float walkSpeed = 5;

    private Rigidbody2D rb;
    private Animator animator;

    private int currentPoint = 0;
    
    private float health = 20;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (Vector3.Distance(patrolPath[currentPoint].position, transform.position) < 0.5f) {
            currentPoint = (currentPoint + 1) % patrolPath.Length;
        }

        rb.linearVelocityX = (patrolPath[currentPoint].position - transform.position).normalized.x * walkSpeed;
        animator.SetBool("isRunning", rb.linearVelocityX * transform.localScale.x > 0.05f);
        if (rb.linearVelocityX > 0) {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (rb.linearVelocityX < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void TakeDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}

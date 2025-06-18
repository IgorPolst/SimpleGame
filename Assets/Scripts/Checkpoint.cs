using UnityEngine;

public class Checkpoint : MonoBehaviour {
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerController>().activeCheckpoint = transform.position;
            foreach (Checkpoint checkpoint in FindObjectsByType<Checkpoint>(FindObjectsSortMode.None)) {
                checkpoint.DisableCheckpoint();
            }
            EnableCheckpoint();
        }
    }

    public void DisableCheckpoint() {
        animator.enabled = false;
    }

    public void EnableCheckpoint() {
        animator.enabled = true;
    }
}

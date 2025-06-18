using UnityEngine;

public class Pickup : MonoBehaviour {
    private Animator animator;
    private AudioSource sound;

    private void Start() {
        animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            animator.SetTrigger("Picked");
            sound.Play();
            Invoke(nameof(DestroyItem), 1.5f);
        }
    }

    private void DestroyItem() {
        Destroy(gameObject);
    }
}

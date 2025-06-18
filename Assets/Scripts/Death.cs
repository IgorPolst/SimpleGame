using UnityEngine;

public class Death : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.transform.position = collision.gameObject.GetComponent<PlayerController>().activeCheckpoint;
        }
    }
}

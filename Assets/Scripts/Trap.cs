using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour {
    [SerializeField] private int damage = 10;
    [SerializeField] private float damageInterval = 1;

    private PlayerController player = null;

    private IEnumerator DealDamage() {
        while (player != null) {
            player.TakeDamage(damage);

            yield return new WaitForSeconds(damageInterval);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            player = collision.gameObject.GetComponent<PlayerController>();
            StartCoroutine(DealDamage());
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            player = null;
            StopAllCoroutines();
        }
    }
}

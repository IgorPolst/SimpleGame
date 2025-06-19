using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] private float speed;

    private void Update() {
        transform.position += speed * Time.deltaTime * transform.localScale.x * Vector3.right;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("DestroyBullet") || collision.gameObject.CompareTag("Ground")) {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy")) {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(10);
            Destroy(gameObject);
        }
    }
}

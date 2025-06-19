using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour {
    [SerializeField] private GameObject endScreen;
    private Menu menu;

    private void Start() {
        menu = FindFirstObjectByType<Menu>();
        endScreen.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            menu.enabled = false;
            Time.timeScale = 0;
            endScreen.SetActive(true);
        }
    }

    public void Restart() {
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }
}

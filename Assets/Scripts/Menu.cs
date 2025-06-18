using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    [SerializeField] private AudioMixer effectsMixer;
    [SerializeField] private AudioMixer musicMixer;

    [SerializeField] private Slider effectsSlider;
    [SerializeField] private Slider musicSlider;

    [SerializeField] private GameObject menu;

    private bool isPaused = false;

    private void Start() {
        effectsSlider.onValueChanged.AddListener(SetEffectsVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);

        effectsSlider.value = PlayerPrefs.GetFloat("effects", 0.5f);
        musicSlider.value = PlayerPrefs.GetFloat("music", 0.5f);

        menu.SetActive(false);
    }

    private void SetEffectsVolume(float value) {
        effectsMixer.SetFloat("volume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("effects", value);
        PlayerPrefs.Save();
    }

    private void SetMusicVolume(float value) {
        musicMixer.SetFloat("volume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("music", value);
        PlayerPrefs.Save();
    }

    private void Update() {
        if (Input.GetButtonDown("Cancel")) {
            if (isPaused) {
                Unpause();
            }
            else {
                isPaused = true;
                Time.timeScale = 0;
                menu.SetActive(true);
            }
        }
    }

    public void Unpause() {
        isPaused = false;
        Time.timeScale = 1;
        menu.SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
    }
}

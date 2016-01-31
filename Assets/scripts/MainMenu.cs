using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public GameObject main;
    public GameObject intro;
    void Update() {
        if (Input.GetButtonDown("Cancel")) {
            QuitGame();
        }
    }
    void Awake() {
        main.SetActive(true);
        intro.SetActive(false);
    }

    public void ShowIntro() {
        main.SetActive(false);
        intro.SetActive(true);
    }

    public void StartGame() {
        // TODO fade out/in
        SceneManager.LoadScene(1);
    }

    public void QuitGame() {
        Debug.Log("Goodbye!");
        // TODO fade out
        Application.Quit();
    }
}

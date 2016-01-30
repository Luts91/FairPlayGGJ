using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    void Update() {
        if (Input.GetButtonDown("Cancel")) {
            QuitGame();
        }
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

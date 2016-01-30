using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class Menu : MonoBehaviour {

    public GameObject startPanel;
    public GameObject endPanel;
    public GameObject pausePanel;

    bool paused = false;

    void Awake() {
        startPanel.SetActive(true);
        endPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    void Update () {
        if (Input.GetButtonDown("Cancel")) {
            TogglePause();
        }
    }

    public void StartGame() {
        startPanel.SetActive(false);
        endPanel.SetActive(false);
    }

    public void NextGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void TogglePause() {
        paused = !paused;
        pausePanel.SetActive(paused);
        Time.timeScale = paused ? 0 : 1;
    }
}

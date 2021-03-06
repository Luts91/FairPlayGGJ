﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class Menu : MonoBehaviour {
    public static Menu instance;

    public GameObject startPanel;
    public GameObject endPanel;
    public GameObject pausePanel;

    bool gameIsPaused = false;
    public bool gameIsRunning = false;

	public UnityEngine.UI.Text winnerText;

    void Awake() {
        instance = this;
        startPanel.SetActive(true);
        endPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    void Update () {
        if ((gameIsRunning || gameIsPaused) && Input.GetButtonDown("Cancel")) {
            TogglePause();
        }
    }

    public void StartGame() {
        startPanel.SetActive(false);
        endPanel.SetActive(false);
        gameIsRunning = true;
    }

    public void NextGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void TogglePause() {
        gameIsPaused = !gameIsPaused;
        gameIsRunning = !gameIsPaused;
        pausePanel.SetActive(gameIsPaused);
        Time.timeScale = gameIsPaused ? 0 : 1;
    }

    public void EndGame(int winner, bool cheated) {
        gameIsRunning = false;
        endPanel.SetActive(true);

		winnerText.text=GameData.IntToCharacterName(winner)+" wins!";

        GameData.instance.winners[SceneManager.GetActiveScene().buildIndex - 1] = winner;
        GameData.instance.cheated[SceneManager.GetActiveScene().buildIndex - 1] = cheated;
    }

    public void BackToMain() {
        GameData.instance.Reset();
        SceneManager.LoadScene(0);
    }
}

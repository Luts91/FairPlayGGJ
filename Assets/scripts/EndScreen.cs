using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour {
    public GameObject main;
    public GameObject outro;
    public Text winner;
    public Text cheated;

    void Awake() {
        main.SetActive(false);
        outro.SetActive(true);
    }

    void Start () {
        winner.text = "And the winners are:";
		winner.text += "\nShouting: " + GameData.IntToCharacterName(GameData.instance.winners[0]);
		winner.text += "\nEating: " + GameData.IntToCharacterName(GameData.instance.winners[1]);
		winner.text += "\nThrowing: " + GameData.IntToCharacterName(GameData.instance.winners[2]);
		winner.text += "\nVolley: " + GameData.IntToCharacterName(GameData.instance.winners[3]);

        cheated.text = "You cheated in:";
        cheated.text += "\nShouting: " + GameData.instance.cheated[0];
        cheated.text += "\nEating: " + GameData.instance.cheated[1];
        cheated.text += "\nThrowing: " + GameData.instance.cheated[2];
        cheated.text += "\nVolley: " + GameData.instance.cheated[3];
    }
    public void BackToMain() {
        GameData.instance.Reset();
        SceneManager.LoadScene(0);
    }
    public void ShowEnding() {
        main.SetActive(true);
        outro.SetActive(false);
    }
    public void QuitGame() {
        Debug.Log("Goodbye!");
        // TODO fade out
        Application.Quit();
    }
}

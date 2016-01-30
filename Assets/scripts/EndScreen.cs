using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour {

    public Text winner;
    public Text cheated;

    void Start () {
        winner.text = "And the winners are:\n";
        winner.text += "Shouting: "+ GameData.instance.winners[0];
        winner.text += "Eating: " + GameData.instance.winners[1];
        winner.text += "Throwing: " + GameData.instance.winners[2];
        winner.text += "Volley: " + GameData.instance.winners[3];

        cheated.text = "You cheated in:\n";
        cheated.text += "Shouting: " + GameData.instance.cheated[0];
        cheated.text += "Eating: " + GameData.instance.cheated[1];
        cheated.text += "Throwing: " + GameData.instance.cheated[2];
        cheated.text += "Volley: " + GameData.instance.cheated[3];
    }
    public void BackToMain() {
        GameData.instance.Reset();
        SceneManager.LoadScene(0);
    }
    public void QuitGame() {
        Debug.Log("Goodbye!");
        // TODO fade out
        Application.Quit();
    }
}

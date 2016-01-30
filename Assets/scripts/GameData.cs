using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {
    public static GameData instance;

    public string[] winners = new string[4];
    public bool[] cheated = new bool[4];

    void Awake() {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

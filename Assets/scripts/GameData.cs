using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {
    public static GameData instance;

    public string[] winners = new string[5];
    public bool[] cheated = new bool[5];

    void Awake() {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Reset() {
        winners = new string[5];
        cheated = new bool[5];
}
}

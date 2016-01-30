using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {
    public static GameData instance;

    public int[] winners = new int[4];
    public bool[] cheated = new bool[4];

    void Awake() {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Reset() {
        winners = new int[4];
        cheated = new bool[4];
	}
}

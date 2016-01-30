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

	public static string IntToCharacterName(int i){
		switch(i){
		case 0:
			return "Steph";
			break;
		case 1:
			return "Alex";
			break;
		case 2:
			return "Jerry";
			break;
		case 3:
			return "Lucy";
			break;
		case 4:
			return "Nicky";
			break;
		}
		return "";
	}
}

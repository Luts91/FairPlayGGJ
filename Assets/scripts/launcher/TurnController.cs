using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnController : MonoBehaviour {
	public List<int> turns;
	public int currentTurn;

	public float[] scores=new float[5];
	public int winner=0;

	public float nextTurnTimer=0;
	public bool nextTurn=false;

	public RotateArrow ra;
	public Stick stick;
	public Sabotager sabotager;



	public static TurnController tc;
	// Use this for initialization
	void Start () {
		tc=this;

		currentTurn=Random.Range(0,5);
	}
	
	// Update is called once per frame
	void Update () {
		if (!Menu.instance.gameIsRunning)
			return;

		if (nextTurn){
			nextTurnTimer+=Time.deltaTime;
			if (nextTurnTimer>=1){
				nextTurn=false;
				nextTurnTimer=0;
				NextTurn();
			}
		}
	}

	public void NextTurn(){
		turns.Add(currentTurn);

		scores[currentTurn]=stick.range;

		if (turns.Count<5){
			ra.enabled=true;
			stick.Restart();
			sabotager.Restart();
			do{
				currentTurn=Random.Range(0,5);
			}while(turns.Contains(currentTurn));
		}else{
			GetWinner();
			Debug.Log(winner+" wins!");
		}
	}

	void GetWinner(){
		for(int i=0; i<5; i++){
			if (scores[i]>scores[winner]){
				winner=i;
			}
		}

		Menu.instance.endPanel.SetActive(true);
		Menu.instance.gameIsRunning=false;
	}


}

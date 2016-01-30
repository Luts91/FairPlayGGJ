﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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

	public bool cheated=false;

	public Text turnText;
	public float turnTextTime;
	bool firstTurn=true;

	public Text rankingText;

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

		if (firstTurn){
			firstTurn=false;
			turnText.enabled=true;
			if (currentTurn==0)
				turnText.text=("Your turn!");
			else
				turnText.text=(GameData.IntToCharacterName(currentTurn)+"'s turn!");
			turnTextTime=2;
		}


		turnTextTime-=Time.deltaTime;
		if (turnTextTime<=0)
			turnText.enabled=false;

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

		string s="Ranking:\n\n";
		for(int i=0; i<5; i++){
			if (scores[i]!=0)
				s+=GameData.IntToCharacterName(i)+": "+Mathf.Round(scores[i]*10)/10+"\n";
		}
		rankingText.text=s;

		if (turns.Count<5){
			ra.enabled=true;
			stick.Restart();
			sabotager.Restart();
			do{
				currentTurn=Random.Range(0,5);
			}while(turns.Contains(currentTurn));

			turnText.enabled=true;
			if (currentTurn==0)
				turnText.text=("Your turn!");
			else
				turnText.text=(GameData.IntToCharacterName(currentTurn)+"'s turn!");
			turnTextTime=2;

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

		Menu.instance.EndGame(winner,cheated);
	}


}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolleyController : MonoBehaviour {

	public static VolleyController vc;

	public Ball ball;

	public int scorePlayer=0,scoreEnemy=0;

	public int winner=-1,finalWinner;


	public int opponent=1;

	public int[] scores=new int[5];

	public Text t;

	public float nextRoundTimer=0;

	// Use this for initialization
	void Start () {
		vc=this;
	}
	
	// Update is called once per frame
	void Update () {

		if (nextRoundTimer>0){
			nextRoundTimer-=Time.deltaTime;

			if (nextRoundTimer<0 && winner>=0){
				ball.enabled=true;
				ball.Restart();
			}
		}
	}

	public void RoundOver(float x){
		if (x<0)
			scoreEnemy+=1;
		else
			scorePlayer+=1;

		if (scorePlayer>=3){
			winner=0;
			NextMatch();
		}
		if (scoreEnemy>=3){
			winner=opponent;
			NextMatch();
		}

		t.text=scorePlayer+":"+scoreEnemy;

		nextRoundTimer=2;

		ball.enabled=false;

	}

	void NextMatch(){
		scores[winner]+=1;

		if (opponent<4)
			opponent+=1;
		else
			GameOver();

		scorePlayer=0;
		scoreEnemy=0;
	}

	void GameOver(){
		for(int i=1; i<5; i++){
			scores[i]+=Random.Range(0,4);
		}

		int finalWinnerScore=0;
		for(int i=0; i<5; i++){
			if (scores[i]>finalWinnerScore){
				finalWinnerScore=scores[i];
				finalWinner=i;
			}
		}
	}
}

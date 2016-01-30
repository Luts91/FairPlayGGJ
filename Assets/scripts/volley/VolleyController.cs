using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolleyController : MonoBehaviour {

	public static VolleyController vc;

	public Ball ball;

	public int scorePlayer=0,scoreEnemy=0;

	public int winner=-1;

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

		if (scorePlayer>=3)
			winner=0;
		if (scoreEnemy>=3)
			winner=1;

		t.text=scorePlayer+":"+scoreEnemy;

		nextRoundTimer=2;

		ball.enabled=false;

	}
}

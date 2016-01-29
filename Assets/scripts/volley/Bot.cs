using UnityEngine;
using System.Collections;

public class Bot : MonoBehaviour {
	public Transform ball;
	public float timerAI=0;
	public float AIntelligence=1;
	public float moveX=0,realMoveX;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timerAI+=Time.deltaTime;

		GetComponent<Character>().Move(realMoveX);

		realMoveX+=(moveX-realMoveX)/10;


		if (timerAI>AIntelligence){
			timerAI=0;
			AIUpdate();
		}
	}


	void AIUpdate(){
		if (ball.position.x>0){
			moveX=ball.position.x-transform.position.x;
			GetComponent<Character>().Jump();
		}else{
			moveX=0;
		}
	}
}

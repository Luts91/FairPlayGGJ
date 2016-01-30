using UnityEngine;
using System.Collections;

public class Bot : MonoBehaviour {
	public Character player;

	public Transform ball;
	public float timerAI=0;
	public float AIntelligence=1;
	public float moveX=0,realMoveX;

	public float sabotageProbability=0.1f, sabotageCooldown=0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timerAI+=Time.deltaTime;

		GetComponent<Character>().Move(realMoveX);

		realMoveX+=(moveX-realMoveX)/5;


		if (timerAI>AIntelligence){
			timerAI=0;
			AIUpdate();
		}
			

		if (sabotageCooldown>0)
			sabotageCooldown-=Time.deltaTime;
	}


	void AIUpdate(){
		if (ball.position.x>0){
			moveX=ball.position.x-transform.position.x+1;
			GetComponent<Character>().Jump();
		}else{
			moveX=0;

			if (Random.value<sabotageProbability && sabotageCooldown<=0){
				sabotageCooldown=2;
				player.stunned=0.5f;
			}
		}
	}
}

﻿using UnityEngine;
using System.Collections;

public class SetStrength : MonoBehaviour {
	public float strength=0,gainPerSec=0.1f;
	public bool increasing=true;
	public Stick stick;

	public float AIGood=0.6f;
	public float AITimer=0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (increasing)
			strength+=gainPerSec*Time.deltaTime;
		else
			strength-=gainPerSec*Time.deltaTime;
			
		if (strength>=1)
			increasing=false;
		if (strength<=0)
			increasing=true;


		if (TurnController.tc.currentTurn==0){
			if (Input.GetMouseButtonUp(0)){
				Throw();
			}
		}else{
			AITimer+=Time.deltaTime;

			if (AITimer>=1 && strength>=AIGood){
				Throw();
			}
		}

		transform.localScale=new Vector3(1,Mathf.Clamp(1-strength,0,1),1);
	}
		
	void OnEnable(){
		AITimer=0;
	}

	void Throw(){
		SoundPlayer.instance.PlaySound(1);

		stick.strength=strength;
		stick.Throw();
		this.enabled=false;
		transform.localScale=new Vector2(1,1);

		TurnController.tc.throwerSprr.sprite=TurnController.tc.throwSpr[TurnController.tc.currentTurn];
	}
}

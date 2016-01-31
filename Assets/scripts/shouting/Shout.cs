using UnityEngine;
using System.Collections;

public class Shout : MonoBehaviour {
	public Transform shoutOmeter;

	public int character=0;
	public float strength=0;
	public float timer=0,maxTimer=5;


	public float AIStrength=0.5f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (!Menu.instance.gameIsRunning) {
            return;
        }
		if (character==0){
			if (Input.GetMouseButtonDown(0)){
				strength+=1;
			}
		}else{
			strength+=Random.value*AIStrength;
		}

		shoutOmeter.localScale=new Vector3(1,1,1)*strength;

		timer+=Time.deltaTime;
		if (timer>=maxTimer){
			ShoutController.sc.RatingPhase(strength);
			this.enabled=false;
		}
	
	}

	void OnEnable(){
		strength=0;
		timer=0;
	}
}

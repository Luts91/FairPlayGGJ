using UnityEngine;
using System.Collections;

public class RotateArrow : MonoBehaviour {

	public float angle,angleMin,angleMax;
	public bool increasing=true;
	public float speed=1;

	public float AIGood=0.6f;
	public float AITimer=0;

	public SetStrength strength;
	public Stick stick;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!Menu.instance.gameIsRunning)
			return;

		if (increasing)
			angle+=speed*Time.deltaTime;
		else
			angle-=speed*Time.deltaTime;

		if (angle>angleMax)
			increasing=false;
		if (angle<angleMin)
			increasing=true;

		transform.rotation=Quaternion.Euler(0,0,angle);

		if (TurnController.tc.currentTurn==0){
			if (Input.GetMouseButtonDown(0)){
				NextStep();
			}
		}else{
			AITimer+=Time.deltaTime;
	
			if (AITimer>1 && angle>=45-(1-AIGood)*45 && angle<=45+(1-AIGood)*45){
				NextStep();
			}
		}
	}

	void OnEnable(){
		AITimer=0;
	}

	void NextStep(){
		this.enabled=false;
		strength.enabled=true;
		stick.angle=angle;
	}

}

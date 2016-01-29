using UnityEngine;
using System.Collections;

public class Sabotager : MonoBehaviour {

	public Vector3 startPos;
	public Stick stick;
	public float strength=10;

	public float sabotageProbability=0.5f;

	public bool thrown=false;
	Rigidbody2D r;

	// Use this for initialization
	void Start () {
		r=GetComponent<Rigidbody2D>();
		startPos=transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (TurnController.tc.currentTurn!=0){
			if (Input.GetMouseButtonDown(0)){
				Throw();
			}
		}else{
			if (Random.value<sabotageProbability && stick.r.velocity.sqrMagnitude>0 && stick.transform.position.x>0){
				Throw();
			}
		}
	}

	void Throw(){
		if (!thrown){
			r.velocity=(stick.transform.position-transform.position).normalized*strength;
			thrown=true;
		}
	}

	public void Restart(){
		transform.position=startPos;
		r.velocity=Vector2.zero;
		thrown=false;
	}
}

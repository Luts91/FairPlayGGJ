using UnityEngine;
using System.Collections;

public class Sabotager : MonoBehaviour {

	public Vector3 startPos;
	public Stick stick;
	public float strength=10;

	public float sabotageProbability=0.5f;

	public bool thrown=false;
	Rigidbody2D r;

	public float canThrow=1;
	public GameObject waterSplash;


	// Use this for initialization
	void Start () {
		r=GetComponent<Rigidbody2D>();
		startPos=transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!Menu.instance.gameIsRunning)
			return;

		canThrow-=Time.deltaTime;

		if (canThrow>0)
			return;


		if (TurnController.tc.currentTurn!=0){
			if (Input.GetMouseButtonDown(0)){
				Throw();
				TurnController.tc.cheated=true;
			}
		}else{
			if (Random.value<sabotageProbability && stick.r.velocity.sqrMagnitude>0 && stick.transform.position.x>0){
				Throw();
			}
		}
	}

	void Throw(){
		if (!thrown){
			r.isKinematic=false;

			r.velocity=(stick.transform.position-transform.position).normalized*strength;
			thrown=true;

			if (TurnController.tc.currentTurn==0){
				TurnController.tc.sabotagerSprr.sprite=TurnController.tc.throwSpr[1];
			}else{
				TurnController.tc.sabotagerSprr.sprite=TurnController.tc.throwSpr[0];
			}
		}
	}

	public void Restart(){
		transform.position=startPos;
		r.velocity=Vector2.zero;
		thrown=false;

		r.isKinematic=true;
	}

	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.GetComponent<Stick>())
			return;

		Instantiate(waterSplash,transform.position,Quaternion.identity);
	}
}

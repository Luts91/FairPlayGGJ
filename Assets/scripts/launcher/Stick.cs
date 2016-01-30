using UnityEngine;
using System.Collections;

public class Stick : MonoBehaviour {

	public float strength,angle,strengthMultiplier=10,range=0;

	public Rigidbody2D r;

	public Vector3 startPos;
	public float startRot;

	public GameObject waterSplash;

	// Use this for initialization
	void Start () {
		r=GetComponent<Rigidbody2D>();
		startPos=transform.position;
		startRot=r.rotation;
		if (TurnController.tc.currentTurn==3)
			transform.position=new Vector3(transform.position.x,transform.position.y-0.7f,transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Throw(){
		transform.rotation=Quaternion.Euler(0,0,angle);

		r.gravityScale=1;

		r.velocity=transform.right*strength*strengthMultiplier;
		r.AddTorque(strength*Random.Range(-300,300));
	}

	public void Restart(){
		transform.position=startPos;
		r.rotation=startRot;
		r.gravityScale=0;
		r.velocity=Vector2.zero;

		if (TurnController.tc.currentTurn==3)
			transform.position=new Vector3(transform.position.x,transform.position.y-0.7f,transform.position.z);
	}

	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.GetComponent<Sabotager>())
			return;

		range=transform.position.x+9;
		TurnController.tc.nextTurn=true;

		Instantiate(waterSplash,transform.position,Quaternion.identity);
	}
}

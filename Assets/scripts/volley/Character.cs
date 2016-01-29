using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public bool isGrounded=false;
	public float jump=10;
	public float moveSpeed=10;
	Rigidbody2D r;

	public float stunned=0;

	// Use this for initialization
	void Start () {
		r=GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (stunned>0){
			stunned-=Time.deltaTime;
		}

	}

	public void Move(float x){
		if  (stunned>0)
			return;

		x=Mathf.Clamp(x,-1,1);
		transform.Translate(new Vector2(x*Time.deltaTime*moveSpeed,0));
	}

	public void Jump(){
		if (stunned>0)
			return;


		int lm=1<<LayerMask.NameToLayer("wall");
		RaycastHit2D hit;
		isGrounded=false;	
		hit=Physics2D.Raycast(transform.position,Vector2.down,1.5f,lm);
		if (hit)
			isGrounded=true;

		if (isGrounded)
			r.velocity=(new Vector2(0,jump));
	}
}

using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	Rigidbody2D r;
	float bounce=100;
	Vector3 startPos;


	// Use this for initialization
	void Start () {
		startPos=transform.position;
		r=GetComponent<Rigidbody2D>();
		Restart();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y>5){
			r.velocity=new Vector2(r.velocity.x,-2);
		}

		int lm=1<<LayerMask.NameToLayer("wall");
		RaycastHit2D hit;
		hit=Physics2D.Raycast(transform.position,Vector2.left,1,lm);
		if (hit)
			Bounce(1,0);
		hit=Physics2D.Raycast(transform.position,Vector2.right,1,lm);
		if (hit)
			Bounce(-1,0);
		hit=Physics2D.Raycast(transform.position,Vector2.down,1,lm);
		if (hit){
			Bounce(0,1);
			if (transform.position.y<-3)
				VolleyController.vc.RoundOver(transform.position.x);
		}
	}

	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.GetComponent<Character>()){
			r.AddForce((transform.position-c.transform.position+Vector3.up*2)*200);
		}
	}

	void Bounce(float x,float y){
		r.AddForce(new Vector2(x*bounce,y*bounce));
	}

	public void Restart(){
		transform.position=startPos;
		r.velocity=new Vector2(Random.value-1+2, Random.value+3);
	}
		
}

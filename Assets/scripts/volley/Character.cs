using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public bool isGrounded=false;
	public float jump=10;
	public float moveSpeed=10;
	Rigidbody2D r;

	public float stunned=0;

	public float startX;

	Animator a;

	// Use this for initialization
	void Start () {
		a=GetComponent<Animator>();
		r=GetComponent<Rigidbody2D>();
		startX=transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (stunned>0){
			stunned-=Time.deltaTime;

			a.SetBool("stunned",true);
		}else{
			a.SetBool("stunned",false);
		}


		int lm=1<<LayerMask.NameToLayer("wall");
		RaycastHit2D hit;
		isGrounded=false;	
		hit=Physics2D.Raycast(transform.position,Vector2.down,1.5f,lm);
		if (hit)
			isGrounded=true;

		if (isGrounded)
			a.SetBool("jumping",false);
		else
			a.SetBool("jumping",true);


		if (startX<0 && transform.position.x>0)
			transform.position=new Vector2(-1,transform.position.y);
		if (startX>0 && transform.position.x<0)
			transform.position=new Vector2(1,transform.position.y);
		if (transform.position.x<-9)
			transform.position=new Vector2(-8,transform.position.y);
		if (transform.position.x>9)
			transform.position=new Vector2(8,transform.position.y);


	}

	public void Move(float x){
		if (!Menu.instance.gameIsRunning)
			return;

		if  (stunned>0)
			return;

		if (x==0)
			a.SetBool("running",false);
		else
			a.SetBool("running",true);

		x=Mathf.Clamp(x,-1,1);
		transform.Translate(new Vector2(x*Time.deltaTime*moveSpeed,0));
	}

	public void Jump(){
		if (!Menu.instance.gameIsRunning)
			return;

		if (stunned>0)
			return;


		if (isGrounded){
			r.velocity=(new Vector2(0,jump));
		

			if (!GetComponent<AudioSource>().isPlaying){
				GetComponent<AudioSource>().Play();
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public Character c, enemy;
	public bool mouseControl=true;

	public float sabotageCooldown=0;

	void Start(){
		c=	GetComponent<Character>();
		c.name="Steph";
	}

	// Update is called once per frame
	void Update () {
		if (sabotageCooldown>0){
			sabotageCooldown-=Time.deltaTime;
		}


		if (!mouseControl){
			c.Move(Input.GetAxis("Horizontal"));

			if (Input.GetAxis("Vertical")>0)
				c.Jump();	


			if (Input.GetKey(KeyCode.Space) && sabotageCooldown<=0){
				VolleyController.vc.cheated=true;
				enemy.stunned=0.5f;
			}
		}else{
			c.Move((Camera.main.ScreenToWorldPoint(Input.mousePosition).x-transform.position.x)/1);

			if (Input.GetMouseButtonDown(0))
				c.Jump();	


			if (Input.GetMouseButtonDown(1) && sabotageCooldown<=0){
				VolleyController.vc.cheated=true;
				enemy.stunned=0.5f;
				SoundPlayer.instance.PlaySound(2);
			}
		}
	}
}

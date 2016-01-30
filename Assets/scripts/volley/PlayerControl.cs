using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public Character c, enemy;

	public float sabotageCooldown=0;

	void Start(){
		c=	GetComponent<Character>();
		c.name="Steph";
	}

	// Update is called once per frame
	void Update () {
		c.Move(Input.GetAxis("Horizontal"));

		if (Input.GetAxis("Vertical")>0)
			c.Jump();	

		if (sabotageCooldown>0){
			sabotageCooldown-=Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.Space) && sabotageCooldown<=0){
			VolleyController.vc.cheated=true;
			enemy.stunned=0.5f;
		}
	}
}

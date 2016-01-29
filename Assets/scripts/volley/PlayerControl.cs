using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public Character c;


	void Start(){
		c=	GetComponent<Character>();
	}

	// Update is called once per frame
	void Update () {
		c.Move(Input.GetAxis("Horizontal"));

		if (Input.GetAxis("Vertical")>0)
			c.Jump();	
	}
}

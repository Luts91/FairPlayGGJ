using UnityEngine;
using System.Collections;

public class WaterSplash : MonoBehaviour {

	float timer=0.5f;

	// Use this for initialization
	void Start () {
		SoundPlayer.instance.PlaySound(2);
	}
	
	// Update is called once per frame
	void Update () {
		timer-=Time.deltaTime;

		if (timer<=0)
			Destroy(gameObject);
	}
}

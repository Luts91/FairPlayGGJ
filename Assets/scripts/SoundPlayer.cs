using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour {
    private AudioSource audioSource;

    public static SoundPlayer instance;
	public List<AudioClip> sounds=new List<AudioClip>();

	void Awake() {
       	instance = this;
        audioSource = GetComponent<AudioSource>();
    }

	public void PlaySound(int i, bool onlyOnce=false) {
		if (!Menu.instance.gameIsRunning)
			return;

		if (onlyOnce && audioSource.isPlaying)
			return;


		Debug.Log("play sound "+i);

		if (sounds.Count>=i+1)
			audioSource.PlayOneShot(sounds[i]);
    }

}

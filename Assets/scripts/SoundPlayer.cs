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

	public void PlaySound(int i) {
		if (sounds.Count>=i)
			audioSource.PlayOneShot(sounds[i]);
    }

}

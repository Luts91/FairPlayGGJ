using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour {
    private AudioSource audioSource;

    public static SoundPlayer instance;
    public AudioClip sound1;

    void Awake() {
        if(instance == null) {
            instance = this;
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound1() {
        audioSource.PlayOneShot(sound1);
    }

}

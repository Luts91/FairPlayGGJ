using UnityEngine;
using System.Collections;

public class Broccoli : MonoBehaviour {
    public static Broccoli instance;
    public float timeToTravel = 1f;
    private SpriteRenderer sr;

    void Awake() {
        instance = this;
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }
    public void ThrowBroccoli(EatContestant from, EatContestant to) {
        StartCoroutine(MoveToPosition(from, to, timeToTravel));
		SoundPlayer.instance.PlaySound(3);
    }

    IEnumerator MoveToPosition(EatContestant from, EatContestant to, float timeToTravel) {
        transform.position = from.transform.position;
        sr.enabled = true;
        float timeStamp = Time.time;
        while (Time.time < timeStamp + timeToTravel) {
            Vector3 currentPos = Vector3.Lerp(from.transform.position, to.transform.position, (Time.time - timeStamp) / timeToTravel);
            currentPos.y += Mathf.Sin(Mathf.Clamp01((Time.time - timeStamp) / timeToTravel) * Mathf.PI);
            transform.position = currentPos;
            yield return 0;
        }
        to.Broccoli();
        sr.enabled = false;
    }
}

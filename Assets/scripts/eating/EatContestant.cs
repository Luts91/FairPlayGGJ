using UnityEngine;
using System;
using System.Collections;

public class EatContestant : MonoBehaviour {

    private GameObject eat_o_meter;
    private GameObject bowl;
    private GameObject persona;

    public bool isPlayer = false;
    public float probability = 0.5f;

    public float increase;
    public float decrease = 0.1f;
    public float brainfreezeThreatLevel = 0f;
    public float upperBoundary = 0.9f;
    public float defreezeBoundary = 0.5f;

    public int bowlFillAmount = 10;
    public bool brainfreeze = false;
    public bool broccoli = false;
    public int eatingscore = 0;
    public int bitesPerPiece = 3;

	public Sprite idle,eat,freeze,brocoli;
	public SpriteRenderer sprr;
	float eating=0;


	public Sprite halfEmptyBowl, almostEmptyBowl;
	public SpriteRenderer bowlSprr;

    void Awake() {
        eat_o_meter = transform.FindChild("Eat-o-meter").gameObject;
        bowl = transform.FindChild("Bowl").gameObject;
        persona = transform.FindChild("Persona").gameObject;

		sprr=persona.GetComponent<SpriteRenderer>();
		bowlSprr=bowl.GetComponent<SpriteRenderer>();
    }
    void Update () {
		if (brainfreeze)
			sprr.sprite=freeze;
		else if (broccoli)
			sprr.sprite=brocoli;
		else if (eating>0)
			sprr.sprite=eat;
		else
			sprr.sprite=idle;

		eating-=Time.deltaTime;


        if (!Menu.instance.gameIsRunning) {
            return;
        }
        if (!brainfreeze && !broccoli) {
            if (!isPlayer && UnityEngine.Random.Range(0f, 1f) < probability * Time.deltaTime && brainfreezeThreatLevel < upperBoundary) {
                Eat();
            }
        }

		DecreaseBrainfreezeThreatLevel();
		eat_o_meter.transform.localScale = new Vector3((1-brainfreezeThreatLevel)*0.3577419f,0.5864619f,1);
	}
    public bool Eat() {
        if (brainfreeze) {
            return false;
        }
        if (broccoli) {
            return false;
        }

		eating=0.2f;

		SoundPlayer.instance.PlaySound(0);

        brainfreezeThreatLevel += increase * Time.deltaTime;
        eatingscore += 1;
        if (eatingscore % bitesPerPiece == 0) {
            bowlFillAmount -= 1;
        }

		if (bowlFillAmount<=5)
			bowlSprr.sprite=halfEmptyBowl;

		if (bowlFillAmount<=2)
			bowlSprr.sprite=almostEmptyBowl;

        if (bowlFillAmount <= 0) {
            
            return true;
        }
        if (brainfreezeThreatLevel > upperBoundary) {
			SoundPlayer.instance.PlaySound(2);

            probability -= 0.1f; // for ai t prevent future freezes
            //persona.GetComponent<Animator>().SetTrigger(FREEZE);
            brainfreeze = true;
            StartCoroutine(RemoveBrainfreezeAfter(2f));
            return true;
        }
        //persona.GetComponent<Animator>().SetTrigger(EAT);
		return true;
    }
    private void DecreaseBrainfreezeThreatLevel() {
        brainfreezeThreatLevel -= (brainfreezeThreatLevel/10 + decrease) * Time.deltaTime;
        if (brainfreezeThreatLevel < 0) {
            brainfreezeThreatLevel = 0;
        }
    }
    public void Defreeze() {
        brainfreeze = false;
    }
	public void Broccoli() {
		SoundPlayer.instance.PlaySound(1);

        broccoli = true;
        //persona.GetComponent<Animator>().SetTrigger(FREEZE);
        StartCoroutine(RemoveBroccoliAfter(2f));
    }
    public IEnumerator RemoveBroccoliAfter(float seconds) {
        yield return new WaitForSeconds(seconds);
        RemoveBroccoli();
    }
    public IEnumerator RemoveBrainfreezeAfter(float seconds) {
        yield return new WaitForSeconds(seconds);
        Defreeze();
    }
    public void RemoveBroccoli() {
        broccoli = false;
    }
    private void Log(string txt) {
        Debug.Log(name + ": " + txt);
    }
}

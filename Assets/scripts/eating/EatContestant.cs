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
    private static int FREEZE = Animator.StringToHash("freeze");
    private static int EAT = Animator.StringToHash("eat");
    private static int WIN = Animator.StringToHash("win");

    void Awake() {
        eat_o_meter = transform.FindChild("Eat-o-meter").gameObject;
        bowl = transform.FindChild("Bowl").gameObject;
        persona = transform.FindChild("Persona").gameObject;
    }
    void Update () {
        if (!Menu.instance.gameIsRunning) {
            return;
        }
        if (!brainfreeze && !broccoli) {
            if (!isPlayer && UnityEngine.Random.Range(0f, 1f) < probability * Time.deltaTime && brainfreezeThreatLevel < upperBoundary) {
                Eat();
            }
            DecreaseBrainfreezeThreatLevel();
        }
        eat_o_meter.transform.localScale = new Vector3(1,brainfreezeThreatLevel*10,1);
	}
    public bool Eat() {
        if (brainfreeze) {
            Log("brainfozen! cant eat");
            return false;
        }
        if (broccoli) {
            Log("broccoli! cant eat");
            return false;
        }
        brainfreezeThreatLevel += increase * Time.deltaTime;
        eatingscore += 1;
        if (eatingscore % bitesPerPiece == 0) {
            bowlFillAmount -= 1;
        }
        if (bowlFillAmount <= 0) {
            Log("i win!");
            // TODO play win animation
            return true;
        }
        if (brainfreezeThreatLevel > upperBoundary) {
            Log("brainfreeze!");
            probability -= 0.1f; // for ai t prevent future freezes
            persona.GetComponent<Animator>().SetTrigger(FREEZE);
            brainfreeze = true;
            StartCoroutine(RemoveBrainfreezeAfter(2f));
            return true;
        }
        persona.GetComponent<Animator>().SetTrigger(EAT);
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
        Log("brainfreeze ended");
    }
    public void Broccoli() {
        broccoli = true;
        Log("broccoli-attack!");
        persona.GetComponent<Animator>().SetTrigger(FREEZE);
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

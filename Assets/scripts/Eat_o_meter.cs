using UnityEngine;

public class Eat_o_meter : MonoBehaviour {

    public bool isPlayer = false;
    public float probability = 0.5f;

    public float increase;
    public float decrease = 0.1f;
    public float brainfreezeThreatLevel = 0.1f;
    public float upperBoundary = 0.9f;
    public float defreezeBoundary = 0.5f;

    public bool brainfreeze = false;
    public bool broccoli = false;
    public float eatingscore = 0;

    void Update () {
	    if (!brainfreeze && !broccoli && !isPlayer && Random.Range(0f, 1f) < probability) {
            Eat();
        }
        DecreaseBrainfreezeThreatLevel();
        transform.localScale = new Vector3(1,brainfreezeThreatLevel,1);
        eatingscore += brainfreezeThreatLevel;
	}
    public void Eat() {
        if (brainfreeze) {
            Log("brainfozen! cant eat");
            return;
        }
        if (broccoli) {
            Log("broccoli! cant eat");
            return;
        }
        brainfreezeThreatLevel += increase * Time.deltaTime;
        if (brainfreezeThreatLevel > upperBoundary) {
            Log("brainfreeze!");
            // TODO play animation
            brainfreeze = true;
        }
        eatingscore += 1;
    }
    private void DecreaseBrainfreezeThreatLevel() {
        brainfreezeThreatLevel -= decrease * Time.deltaTime;
        if (brainfreeze && brainfreezeThreatLevel < defreezeBoundary) {
            // TODO maybe replace that with timing (after animation finishes)
            Defreeze();
        }
        if (brainfreezeThreatLevel < 0) {
            brainfreezeThreatLevel = 0;
        }
    }
    private void Defreeze() {
        brainfreeze = false;
        Log("brainfreeze ended");
    }
    public void Broccoli() {
        broccoli = true;
        Log("broccoli-attack!");
        //TODO play animation
    }

    private void Log(string txt) {
        Debug.Log(name + ": " + txt);
    }
}

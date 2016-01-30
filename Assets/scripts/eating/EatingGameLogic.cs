using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class EatingGameLogic : MonoBehaviour {
    public static EatingGameLogic instance;

    public GameObject startPanel;
    public GameObject endPanel;

    public bool gameIsRunning = false;

    public EatContestant player;
    public EatContestant ai1;
    public EatContestant ai2;
    public EatContestant ai3;
    public EatContestant ai4;

    public List<EatContestant> eatContestants = new List<EatContestant>();
    private float lastAttack = 0f;
    private float attackCooldown = 5f;
    private int attackCount = 0;

    void Awake() {
        instance = this;
        startPanel.SetActive(true);
        endPanel.SetActive(false);
        eatContestants.Add(player);
        eatContestants.Add(ai1);
        eatContestants.Add(ai2);
        eatContestants.Add(ai3);
        eatContestants.Add(ai4);
    }

    void Update() {
        if (gameIsRunning) {
            EatContestant leader = GetLeadingOpponent();

            if (Input.GetButtonDown("Fire1")) {
                // take a bite
                player.Eat();

                // counterattack 
                if (UnityEngine.Random.Range(0f, 1f) < attackCount / 10) {
                    player.Broccoli();
                }

            }
            if (Input.GetButtonDown("Fire2")) {
                if (lastAttack == 0f || lastAttack < Time.realtimeSinceStartup - attackCooldown) {
                    // sabotage
                    lastAttack = Time.realtimeSinceStartup; // for cooldown
                    leader.Broccoli();
                    attackCount += 1;
                } else {
                    Debug.Log("attack is on cooldown");
                }

            }
            // check for a winner
            foreach (EatContestant ec in eatContestants) {
                if (ec.bowlFillAmount <= 0) {
                    // we have a winner
                    gameIsRunning = false;
                    // set name of the winnner etc
                    endPanel.SetActive(true);
                    GameData.instance.winners[SceneManager.GetActiveScene().buildIndex - 1] = ec.name; // TODO change to real name
                    GameData.instance.cheated[SceneManager.GetActiveScene().buildIndex - 1] = (attackCount > 0);
                    return;
                }
            }
        }
    }

    public void StartContest() {
        gameIsRunning = true;
    }

    private EatContestant GetLeadingOpponent() {
        EatContestant leader = ai1;
        if (ai2.eatingscore > leader.eatingscore) {
            leader = ai2;
        }
        if (ai3.eatingscore > leader.eatingscore) {
            leader = ai3;
        }
        if (ai4.eatingscore > leader.eatingscore) {
            leader = ai4;
        }
        return leader;
    }
}

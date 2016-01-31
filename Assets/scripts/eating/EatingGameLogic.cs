using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class EatingGameLogic : MonoBehaviour {
    public static EatingGameLogic instance;

    public EatContestant steph;
    public EatContestant alex;
    public EatContestant jerry;
    public EatContestant lucy;
    public EatContestant nicky;

    public List<EatContestant> eatContestants = new List<EatContestant>();
    private float lastAttack = 0f;
    private float attackCooldown = 3f;
    private int attackCount = 0;
    private AudioSource[] audiosources;

    void Awake() {
        instance = this;
        eatContestants.Add(steph);
        eatContestants.Add(alex);
        eatContestants.Add(jerry);
        eatContestants.Add(lucy);
        eatContestants.Add(nicky);
        audiosources = GetComponents<AudioSource>();
    }

    public void StartBackgroundSound() {
        audiosources[0].Play();
        audiosources[1].Play();
    }
    public void StopBackgroundSound() {
        audiosources[0].Stop();
        audiosources[1].Stop();
    }

    void Update() {
        if (!Menu.instance.gameIsRunning) {
            return;
        }
        EatContestant leader = GetLeadingOpponent();

        if (Input.GetButtonDown("Fire1")) {
            // take a bite
            bool success = steph.Eat();
            if (success) {
                // counterattack 
                double probabilityOfCounterattack = Math.Sin(Math.Min(1f, attackCount / 10f) * Math.PI / 2) / 2;
               // Debug.Log("probabilityOfCounterattack=" + probabilityOfCounterattack);
                if (UnityEngine.Random.Range(0f, 1f) < probabilityOfCounterattack) {
                    Broccoli.instance.ThrowBroccoli(leader, steph);
                }
            }

        }
        if (Input.GetButtonDown("Fire2")) {
            if (lastAttack == 0f || lastAttack < Time.realtimeSinceStartup - attackCooldown) {
                // sabotage
                lastAttack = Time.realtimeSinceStartup; // for cooldown
                Broccoli.instance.ThrowBroccoli(steph, leader);
                attackCount += 1;
            } else {
           //     Debug.Log("attack is on cooldown");
            }

        }
        // check for a winner
        for (int i = 0; i < eatContestants.Count; i++) {
            EatContestant ec = eatContestants[i];
            if (ec.bowlFillAmount <= 0) {
                Menu.instance.EndGame(i, (attackCount > 0));
                StopBackgroundSound();
				SoundPlayer.instance.PlaySound(4);
                return;
            }
        }
    }

    private EatContestant GetLeadingOpponent() {
        EatContestant leader = alex;
        if (jerry.eatingscore > leader.eatingscore) {
            leader = jerry;
        }
        if (lucy.eatingscore > leader.eatingscore) {
            leader = lucy;
        }
        if (nicky.eatingscore > leader.eatingscore) {
            leader = nicky;
        }
        return leader;
    }
}

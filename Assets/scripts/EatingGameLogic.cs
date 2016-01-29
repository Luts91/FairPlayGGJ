using UnityEngine;
using System.Collections;
using System;

public class EatingGameLogic : MonoBehaviour {

    public Eat_o_meter player;
    public Eat_o_meter ai1;
    public Eat_o_meter ai2;
    public Eat_o_meter ai3;
    public Eat_o_meter ai4;

    void Update() {
        GetLeadingOpponent();

        if (Input.GetButtonDown("Fire1")) {
            // take a bite
            player.Eat();
        }
        if (Input.GetButtonDown("Fire2")) {
            // sabotage
            GetLeadingOpponent().Broccoli();
        }
    }

    private Eat_o_meter GetLeadingOpponent() {
        Eat_o_meter leader = ai1;
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

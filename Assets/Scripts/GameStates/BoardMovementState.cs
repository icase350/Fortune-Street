using GDEUtils.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMovementState : State<GameController> {
    public static BoardMovementState I { get; private set; }

    private void Awake() {
        I = this;
    }

    public override void Execute() {
        Player.I.HandleUpdate();
    }
}

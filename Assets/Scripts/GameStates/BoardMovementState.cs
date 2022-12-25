using GDEUtils.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMovementState : State<GameController> {
    public static BoardMovementState I { get; private set; }

    private void Awake() {
        I = this;
    }

    GameController gc;
    public override void Enter(GameController owner) {
        gc = owner;
        Player.I.BeginTurn();
    }

    public override void Execute() {
        Player.I.HandleUpdate();

        if(Player.I.Phase == TurnPhase.Rolling && Input.GetButtonDown("Back")) {
            gc.StateMachine.Pop();
        }
    }

    public override void Exit() {
        Player.I.Exit();
    }
}

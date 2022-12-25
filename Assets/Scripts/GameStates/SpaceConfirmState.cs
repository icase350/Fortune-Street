using GDEUtils.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceConfirmState : State<GameController> {
    [SerializeField] private SpaceConfirmController confirmMenu;

    public static SpaceConfirmState I { get; private set; }
    private void Awake() {
        I = this;
    }

    GameController gc;
    public override void Enter(GameController owner) {
        gc = owner;
        confirmMenu.gameObject.SetActive(true);
        confirmMenu.OnSelected += OnMenuItemSelected;
    }

    public override void Execute() {
        confirmMenu.HandleUpdate();
        if (Input.GetButtonDown("Back")) {
            gc.StateMachine.Pop();
        }
    }

    public override void Exit() {
        confirmMenu.gameObject.SetActive(false);
        confirmMenu.OnSelected -= OnMenuItemSelected;
    }

    void OnMenuItemSelected(int selection) {
        switch (selection) {
            case 0: Player.I.EndTurn(); break;
            case 1: Player.I.UndoMove(); break;
        }
        gc.StateMachine.Pop();
    }
}

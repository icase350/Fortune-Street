using GDEUtils.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuState : State<GameController> {
    [SerializeField] PlayerMenuController playerMenu;

    public static PlayerMenuState I { get; private set; }
    private void Awake() {
        I = this;
    }

    GameController gc;
    public override void Enter(GameController owner) {
        gc = owner;
        playerMenu.gameObject.SetActive(true);

        playerMenu.OnSelected += OnMenuItemSelected;
    }

    public override void Execute() {
        playerMenu.HandleUpdate();
    }

    public override void Exit() {
        playerMenu.gameObject.SetActive(false);

        playerMenu.OnSelected -= OnMenuItemSelected;
    }

    void OnMenuItemSelected(int selection) {
        switch (selection) {
            case 0: gc.StateMachine.Push(BoardMovementState.I); break; // Roll
            case 1: // View Board
            case 2: // Sell Stocks
            case 3: // Manage Shops
            case 4: // Other
            default: Debug.Log($"Selected option {selection}"); break;
        }
    }

    public override void SoftEnter() {
        playerMenu.gameObject.SetActive(true);
    }

    public override void SoftExit() {
        playerMenu.gameObject.SetActive(false);
    }
}

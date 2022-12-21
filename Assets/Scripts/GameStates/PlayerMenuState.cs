using GDEUtils.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuState : State<GameController> {
    public static PlayerMenuState I { get; private set; }
    private void Awake() {
        I = this;
    }
}

using GDEUtils.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public StateMachine<GameController> StateMachine { get; private set; }

    private bool drawDebugGUI = false;

    private void Start() {
        StateMachine = new StateMachine<GameController>(this);
        StateMachine.ChangeState(PlayerMenuState.I);
    }

    private void Update() {
        StateMachine.Execute();

        if (Input.GetKeyDown(KeyCode.F3))
            drawDebugGUI = !drawDebugGUI;
    }

    private void OnGUI() {
        if(drawDebugGUI) {
            var style = new GUIStyle();
            style.fontSize = 36;

            GUILayout.Label("STATE STACK", style);
            foreach(var state in StateMachine.StateStack) {
                GUILayout.Label(state.GetType().ToString(), style);
            }
        }
    }
}

/*
 *  Game Flow
 * 
 *  Player Menu
 *      Roll
 *      View Board
 *      Sell Stocks
 *      Manage Shops
 *      Other
 *  
 *  Roll
 *      Roll the die -> Move number of spaces [space pass interaction] -> Confirm stopping space -> space stop interaction -> update board -> next player turn
 *  
 *  View Board
 *      Move camera about the board and investigate spaces and general layout
 *  
 *  Sell Stocks
 *      Open Stock Menu
 *          Can sell any number of owned stocks -> update board
 *  
 *  Manage Shops
 *      Sell Shop
 *      Trade
 *      Auction?
 *      Manage Vacant Plots
 *  
 *  Other Menu
 *      Individual Standing
 *      Overall Standing
 *      Target Conditions
 *      Options
 *      Out for Lunch
 *      Abandon Game
 */

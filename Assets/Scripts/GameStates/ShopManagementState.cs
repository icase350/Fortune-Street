using GDEUtils.StateMachine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class ShopManagementState : State<GameController>
{
    // Input
    public Player Player { get; set; }
    public Shop Shop { get; set; }


    GameController gc;
    public static ShopManagementState Instance { get; private set; }
    private void Awake() {
        Instance = this;
    }

    public override void Enter(GameController owner) {
        gc = owner;
    }

    public override void Execute() {
        if (Shop.Owner == null) {
            //TODO: prompt to buy
            Player.AdjustCash(-Shop.Value);
            Shop.Owner = Player;
        } else if (Shop.Owner == Player) {
            //TODO: prompt to invest
        } else {
            Player.AdjustCash(-Shop.Price);
            if (Player.Cash > Shop.TotalValue() * 5) {
                //TODO: prompt to force buyout
            }
        }
    }

    public override void Exit() {
        
    }
}

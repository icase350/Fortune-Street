using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private Die die;
    [SerializeField] private PlayerHUDPanel hudPanel;
    private GamePiece piece;

    public Die Die => die;
    public TurnPhase Phase { get; private set; }
    public static Player I { get; private set; }

    public int Cash { get; private set; }
    public int NetWorth { get; private set; }
    public int Level { get; private set; }

    private void Start() {
        I = this;
        piece = GetComponent<GamePiece>();
        Phase = TurnPhase.Rolling;
        Cash = 1000;
        CalculateNetWorth();
        hudPanel.Init("P1", 1000, NetWorth);
        Level = 1;
    }

    public void HandleUpdate() {
        if (Phase == TurnPhase.Rolling) {
            if (Input.GetButtonDown("Action")) {
                die.StopRolling();
                piece.Steps = die.Value;
                Phase = TurnPhase.Moving;
            }
        } else if (Phase == TurnPhase.Moving) {
            if (!piece.IsMoving) {
                float x = Input.GetAxis("Horizontal");
                float z = Input.GetAxis("Vertical");
                if (x != 0 || z != 0) {
                    piece.TryMove(new Vector3(x, 0f, z).normalized);
                }
            }
        }
    }

    public void BeginTurn() {
        Phase = TurnPhase.Rolling;
        die.gameObject.SetActive(true);
        die.StartRolling();
    }

    public void Exit() {
        die.State = DieState.Stopped;
        die.gameObject.SetActive(false);
    }

    public void EndTurn() {
        piece.EndTurn();
        piece.CurrentNode.GetComponent<IBoardSpace>()?.Land(this);
        GameController.I.StateMachine.Pop();
    }

    internal void UndoMove() {
        StartCoroutine(piece.TryMove(piece.History.Peek()));
    }

    public void CalculateNetWorth() {
        int total = 0;
        // Add total property value
        // Add total stock value
        // Add cash
        total += Cash;

        NetWorth = total;
    }

    public bool GrantSuit(Suit currentSuit) {
        bool granted = hudPanel.AddSuit(currentSuit);
        if(!granted) {
            AdjustCash(100 * Level);
        }
        return granted;
    }

    public void UnGrantSuit(Suit suit, bool granted) {
        if(granted) {
            hudPanel.RemoveSuit(suit);
        } else {
            AdjustCash(-100 * Level);
        }
    }

    public void AdjustCash(int amount) {
        Cash += amount;
        NetWorth += amount;
        UpdateUI();
    }

    private void UpdateUI() {
        hudPanel.UpdateUI(Cash, NetWorth);
    }

    internal IBoardSpace GetCurrentSpace() {
        return piece.CurrentNode.GetComponent<IBoardSpace>();
    }
}

public enum TurnPhase {
    Rolling, Moving
}

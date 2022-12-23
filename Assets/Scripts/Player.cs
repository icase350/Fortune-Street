using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private Die die;
    private GamePiece piece;

    public Die Die => die;
    public TurnPhase Phase { get; private set; }
    public static Player I { get; private set; }

    private void Start() {
        I = this;
        piece = GetComponent<GamePiece>();
        Phase = TurnPhase.Rolling;
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
}

// TODO: Allow player to move about the board but limited by steps
// Implement history stack to allow player to move backward toward space where turn started
// When all steps are exhausted, prompt player to confirm stopping space
// Return to PlayerMenuState

public enum TurnPhase {
    Rolling, Moving
}

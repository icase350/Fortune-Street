using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private GamePiece piece;

    public TurnPhase Phase { get; private set; }

    public static Player I { get; private set; }

    private void Start() {
        I = this;
        piece = GetComponent<GamePiece>();
    }

    public void HandleUpdate() {
        if (!piece.IsMoving) {
            //float x = 0, z = 0;
            //if (Input.GetKeyDown(KeyCode.W)) {
            //    z += 1;
            //}
            //if (Input.GetKeyDown(KeyCode.S)) {
            //    z -= 1;
            //}
            //if (Input.GetKeyDown(KeyCode.D)) {
            //    x += 1;
            //}
            //if (Input.GetKeyDown(KeyCode.A)) {
            //    x -= 1;
            //}
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            if (x != 0 || z != 0) {
                piece.TryMove(new Vector3(x, 0f, z).normalized);
            }
        }
    }

    public void BeginTurn() {
        Phase = TurnPhase.Rolling;
        // TODO: Die rolling and restricted movement
    }
}

public enum TurnPhase {
    Rolling, Moving
}

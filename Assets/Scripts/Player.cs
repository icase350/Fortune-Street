using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private GamePiece piece;

    private void Awake() {
        piece = GetComponent<GamePiece>();
    }

    private void FixedUpdate() {
        if (!piece.IsMoving) {
            int x = 0, z = 0;
            if (Input.GetKeyDown(KeyCode.W)) {
                z += 1;
            }
            if (Input.GetKeyDown(KeyCode.S)) {
                z -= 1;
            }
            if (Input.GetKeyDown(KeyCode.D)) {
                x += 1;
            }
            if (Input.GetKeyDown(KeyCode.A)) {
                x -= 1;
            }
            if (x != 0 || z != 0) {
                piece.TryMove(new Vector3(x, 0, z).normalized);
            }
        }
    }
}
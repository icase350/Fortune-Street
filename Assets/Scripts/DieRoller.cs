using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DieRoller : MonoBehaviour {
    [SerializeField] private Die die;
    private bool dieRolling = false;

    private void Update() {
        if (!dieRolling) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                dieRolling = true;
                StartCoroutine(RollDie());
            }
        }
    }

    private IEnumerator RollDie() {
        die.gameObject.SetActive(true);
        die.State = DieState.Rolling;
        yield return new WaitForSeconds(2f);
        die.State = DieState.Stopped;
        yield return new WaitForEndOfFrame();
        int result = die.StopRolling();
        Debug.Log($"Die result: {result}");
        yield return new WaitForSeconds(2f);
        die.gameObject.SetActive(false);
        dieRolling = false;
    }
}

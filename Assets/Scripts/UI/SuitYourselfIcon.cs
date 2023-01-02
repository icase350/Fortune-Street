using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SuitYourselfIcon : SuitIcon {
    private TextMeshPro numText;
    private void Awake() {
        numText = GetComponentInChildren<TextMeshPro>();
    }

    public int Number { get; private set; }

    public void Set(int count) {
        if (count < 0) {
            Number = 0;
        } else {
            Number = count;
        }
        
        if(Number >= 2) {
            TurnOn();
            numText.gameObject.SetActive(true);
            numText.text = Number.ToString();
        } else if(Number == 0) {
            TurnOff();
            numText.gameObject.SetActive(false);
        } else {
            TurnOn();
            numText.gameObject.SetActive(false);
        }
    }
}

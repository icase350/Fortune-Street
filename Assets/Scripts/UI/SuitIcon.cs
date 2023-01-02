using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuitIcon : MonoBehaviour {
    [SerializeField] private Image imageComponent;

    [SerializeField] private Sprite activeImage;
    [SerializeField] private Sprite inactiveImage;

    public bool Active { get; private set; }

    private void Awake() {
        Active = false;
        TurnOff();
    }

    public void TurnOn() {
        if (!Active) {
            Active = true;
            imageComponent.sprite = activeImage;
        }
    }

    public void TurnOff() {
        if (Active) {
            Active = false;
            imageComponent.sprite = inactiveImage;
        }
    }
}

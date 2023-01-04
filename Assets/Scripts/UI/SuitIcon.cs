using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuitIcon : MonoBehaviour {
    [SerializeField] private Image imageComponent;

    [SerializeField] private Sprite activeImage;
    [SerializeField] private Sprite inactiveImage;

    public bool Active { get; private set; }

    public void TurnOn() {
        Active = true;
        imageComponent.sprite = activeImage;
    }

    public void TurnOff() {
        Active = false;
        imageComponent.sprite = inactiveImage;
    }
}

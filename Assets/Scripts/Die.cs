using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Die : MonoBehaviour {
    [SerializeField] private List<Sprite> dieFaces = new List<Sprite>(8);
    private Image image;
    public int Value { get; private set; }

    private void Awake() {
        image = GetComponentInChildren<Image>();
    }

    public void ChangeValue(int newValue) {
        if (newValue >= 1 && newValue < dieFaces.Count) {
            Value = newValue;
            image.sprite = dieFaces[Value - 1];
        }
    }
}

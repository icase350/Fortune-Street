using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Die : MonoBehaviour {
    [SerializeField] private List<Sprite> dieFaces = new List<Sprite>(8);
    private Image image;
    public int Value { get; private set; }
    public DieState State { get; set; }

    private int frame = 0;

    private void Awake() {
        image = GetComponentInChildren<Image>();
        State = DieState.Stopped;
    }

    public void ChangeValue(int newValue) {
        if (newValue >= 1 && newValue <= dieFaces.Count) {
            Value = newValue;
            image.sprite = dieFaces[Value - 1];
        }
    }

    public int StopRolling() {
        int result = Random.Range(0, dieFaces.Count) + 1;
        ChangeValue(result);
        return result;
    }

    private void FixedUpdate() {
        if(State == DieState.Rolling && frame == 0) {
            ChangeValue(Random.Range(0, dieFaces.Count) + 1);
        }
        frame++;
        frame %= 3;
    }
}

public enum DieState {
    Rolling, Stopped
}

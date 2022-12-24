using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Die : MonoBehaviour {
    [SerializeField] private List<Sprite> dieFaces = new List<Sprite>(8);
    [SerializeField] private Image image;
    private float timer = 0f;
    private readonly float timerSpeed = 12f;

    public int Value { get; private set; }
    public DieState State { get; set; }

    private void Awake() {
        State = DieState.Stopped;
    }

    public void ChangeValue(int newValue) {
        if (newValue >= 1 && newValue <= dieFaces.Count) {
            Value = newValue;
            image.sprite = dieFaces[Value - 1];
        }
    }

    public void StartRolling() {
        State = DieState.Rolling;
    }

    public int StopRolling() {
        State = DieState.Stopped;
        timer = 0f;
        int result = Random.Range(0, dieFaces.Count) + 1;
        ChangeValue(result);
        return result;
    }

    private void FixedUpdate() {
        if (State == DieState.Rolling) {
            if (timer == 0) {
                ChangeValue(Random.Range(0, dieFaces.Count) + 1);
                SetTimer();
            }
            UpdateTimer();
        }
    }

    void SetTimer() {
        timer = 1 / timerSpeed;
    }

    void UpdateTimer() {
        if (timer > 0)
            timer = Mathf.Clamp(timer - Time.deltaTime, 0, timer);
    }
}

public enum DieState {
    Rolling, Stopped
}

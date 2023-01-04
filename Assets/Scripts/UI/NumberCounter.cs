using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class NumberCounter : MonoBehaviour {
    public TextMeshProUGUI text;
    public int countFPS = 30;
    public float duration = 1f;
    private int _value;
    public int Value {
        get {
            return _value;
        }
        set {
            UpdateText(value);
            _value = value;
        }
    }
    private Coroutine countingCoroutine;

    private void Awake() {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void UpdateText(int newValue) {
        if (countingCoroutine != null) {
            StopCoroutine(countingCoroutine);
        }

        countingCoroutine = StartCoroutine(CountText(newValue));
    }

    private IEnumerator CountText(int newValue) {
        WaitForSeconds Wait = new WaitForSeconds(1f / countFPS);
        int previousValue = _value;
        int stepAmount;

        if (newValue - previousValue < 0) {
            stepAmount = Mathf.FloorToInt((newValue - previousValue) / (countFPS * duration));
        } else {
            stepAmount = Mathf.CeilToInt((newValue - previousValue) / (countFPS * duration));
        }

        if (previousValue < newValue) {
            while (previousValue < newValue) {
                previousValue += stepAmount;
                if (previousValue > newValue) {
                    previousValue = newValue;
                }

                text.SetText(previousValue.ToString("N0"));

                yield return Wait;
            }
        } else {
            while (previousValue > newValue) {
                previousValue += stepAmount;
                if (previousValue < newValue) {
                    previousValue = newValue;
                }

                text.SetText(previousValue.ToString("N0"));

                yield return Wait;
            }
        }
    }
}

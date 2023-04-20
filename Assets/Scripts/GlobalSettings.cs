using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour {
    [SerializeField] Color highlightColor;
    [SerializeField] Color highlightTextColor;
    [SerializeField] int[] starThresholds;

    public Color HighlightColor => highlightColor;
    public Color HighlightTextColor => highlightTextColor;
    public int[] StarThresholds => starThresholds;

    public static GlobalSettings I { get; private set; }

    private void Awake() {
        I = this;
    }
}

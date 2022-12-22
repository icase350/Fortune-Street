using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, ISelectableItem
{    
    private Color originalColor;
    private Color originalColorText;

    private Image image;
    private TextMeshProUGUI text;

    public void Init() {
        image = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        originalColor = image.color;
        originalColorText = text.color;
    }

    public void OnSelectionChanged(bool selected) {
        if (selected)
            Select();
        else
            UnSelect();
    }

    public void Select() {
        image.color = GlobalSettings.I.HighlightColor;
        text.color = GlobalSettings.I.HighlightTextColor;
    }

    public void UnSelect() {
        image.color = originalColor;
        text.color = originalColorText;
    }
}

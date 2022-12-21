using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{    
    private Color originalColor;
    private Color originalColorText;

    private Image image;
    private TextMeshProUGUI text;

    private void Start() {
        image = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        originalColor = image.color;
        originalColorText = text.color;
    }

    public void Select() {
        image.color = Color.yellow;
        text.color = Color.black;
    }

    public void UnSelect() {
        image.color = originalColor;
        text.color = originalColorText;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopInfoPanel : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI districtText;
    [SerializeField] private TextMeshProUGUI shopNameText;
    [SerializeField] private TextMeshProUGUI shopValueText;
    [SerializeField] private TextMeshProUGUI shopPriceText;
    [SerializeField] private TextMeshProUGUI shopCapitalText;
    [SerializeField] private Image starsImage;
    [SerializeField] private Image shopImage;
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private GameObject descriptionPanel;
    [SerializeField] private TextMeshProUGUI shopDescriptionText;

    [Header("Images")]
    [SerializeField] private Sprite[] stars;
    [SerializeField] private Sprite[] shops;
    [SerializeField] private Sprite[] circusTents;
    [SerializeField] private Sprite balloonport;
    [SerializeField] private Sprite checkpoint;
    [SerializeField] private Sprite estateAgency;
    [SerializeField] private Sprite house;
    [SerializeField] private Sprite taxOffice;

    public void Init(Shop shop) {
        districtText.text = "District " + shop.District.ToString();
        shopNameText.text = shop.Name;
        shopValueText.text = shop.Value.ToString();
        shopPriceText.text = shop.Price.ToString();
        shopCapitalText.text = shop.GetRemainingCapital().ToString();
        starsImage.sprite = stars[shop.StarLevel - 1];
        shopImage.sprite = shops[shop.StarLevel - 1];
        //TODO: shopDescriptionText.text = shop.Description;

        infoPanel.SetActive(true);
        descriptionPanel.SetActive(false);
    }
}

public enum BuildingType {
    Balloonport, Checkpoint, Circus, EstateAgency, House, Shop, TaxOffice
}

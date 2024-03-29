using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour, IBoardSpace {
    [SerializeField] private ShopBase shopBase;
    [SerializeField] private District district;

    public Player Owner { get; set; }
    public District District => district;
    public string Name => shopBase.ShopName;
    public int Value { get; private set; }
    public int Price { get; private set; }
    public int MaxCapital { get; private set; }
    public int InvestedCapital { get; private set; }
    public int StarLevel { get; private set; }
    public ShopStatus Status { get; private set; }

    private void Start() {
        Owner = null;
        Value = shopBase.StartingValue;
        Price = Value / 10;
        MaxCapital = Value / 4;
        InvestedCapital = 0;
        StarLevel = CalcStarLevel();
        Status = ShopStatus.Normal;
    }

    public void Land(Player player) {
        ShopManagementState.Instance.Player = player;
        ShopManagementState.Instance.Shop = this;
        GameController.I.StateMachine.Push(ShopManagementState.Instance);
    }

    public void Pass(Player player) {
        Debug.Log($"Passed {Name}");
    }

    public void Refresh() {
        Debug.Log($"{shopBase.ShopName} has been refreshed");
    }

    public void UndoPass(Player player) {
        Debug.Log($"Unpassed {shopBase.ShopName}");
    }

    private int CalcStarLevel() {
        int totalValue = TotalValue();
        int index = GlobalSettings.I.StarThresholds.Length - 1;
        while (index >= 0) {
            if (totalValue >= GlobalSettings.I.StarThresholds[index]) {
                break;
            }
            index--;
        }
        if (index < 0)
            return 1;
        else
            return index + 2;
    }

    public int TotalValue() {
        return Value + (InvestedCapital > MaxCapital ? MaxCapital : InvestedCapital);
    }

    public int GetRemainingCapital() {
        return Mathf.Clamp(MaxCapital - InvestedCapital, 0, MaxCapital);
    }
}

public enum District {
    A, B, C, D, E, F, G, H, I, J, K, L
}

public enum ShopStatus {
    Normal, Half, Extra, Flat, Closed
}

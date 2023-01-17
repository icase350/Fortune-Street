using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour, IBoardSpace {
    [SerializeField] private ShopBase shopBase;

    public Player Owner { get; private set; }
    public District District { get; private set; }
    public int Value { get; private set; }
    public int Price { get; private set; }
    public int MaxCapital { get; private set; }
    public int InvestedCapital { get; private set; }
    public int StarLevel { get; private set; }
    public ShopStatus Status { get; private set; }

    public void Land(Player player) {
        /*
         *  if unowned
         *      prompt to buy
         *  if owned
         *      if player == owner
         *          prompt to invest in any owned shop
         *      else
         *          player pays shop price
         *          if player networth > shop value * 5
         *              prompt player to force buyout
         */
    }

    public void Pass(Player player) {
        Debug.Log($"Passed {shopBase.ShopName}");
    }
}

public enum District {
    A, B, C, D, E, F, G, H, I, J, K, L
}

public enum ShopStatus {
    Normal, Half, Extra, Flat, Closed
}

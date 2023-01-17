using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shop", menuName = "Shop/Create new shop")]
public class ShopBase : ScriptableObject
{
    [SerializeField] private string shopName;
    [SerializeField] private int startingValue;

    public string ShopName => shopName;
    public int StartingValue => startingValue;
}

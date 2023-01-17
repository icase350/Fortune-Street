using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHUDPanel : MonoBehaviour {
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI playerText;
    [SerializeField] private NumberCounter cashText;
    [SerializeField] private NumberCounter netWorthText;
    [Header("Suits")]
    [SerializeField] private SuitYourselfIcon suitYourself;
    [SerializeField] private List<SuitIcon> suitList;

    public void Init(string playerName, int startingCash, int startingWorth) {
        playerText.text = playerName;
        cashText.Value = startingCash;
        netWorthText.Value = startingWorth;

        suitYourself.Set(0);
        foreach (SuitIcon suit in suitList) {
            suit.TurnOff();
        }
    }

    public bool CanLevelUp() {
        int suits = 0;
        foreach (SuitIcon suit in suitList) {
            if (suit.Active) suits++;
        }
        if (suits < 4) suits += suitYourself.Number;
        return suits >= 4;
    }

    public void LevelUp() {
        int suits = 4;
        foreach (SuitIcon suit in suitList) {
            if (suit.Active) {
                suit.TurnOff();
                suits--;
            }
        }
        if (suits > 0) {
            suitYourself.Set(suitYourself.Number - suits);
        }
    }

    public bool AddSuit(Suit s) {
        int i = 0;
        switch (s) {
            case Suit.Spade: i = 0; break;
            case Suit.Heart: i = 1; break;
            case Suit.Diamond: i = 2; break;
            case Suit.Club: i = 3; break;
        }
        bool added = false;
        if (!suitList[i].Active) {
            suitList[i].TurnOn();
            added = true;
        }
        return added;
    }
}

public enum Suit {
    Spade, Heart, Diamond, Club
}

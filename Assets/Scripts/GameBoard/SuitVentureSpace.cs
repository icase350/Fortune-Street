using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitVentureSpace : MonoBehaviour, IBoardSpace {
    [SerializeField] private bool isSuitSpace;
    [SerializeField] private Suit currentSuit;
    [SerializeField] private bool isRotatingSuit;

    public void Land(Player player) {
        // Pick venture card
    }

    public void Pass(Player player) {
        /*
         *  if suit space
         *      grant current suit to player
         *      if isRotatingSuit
         *          rotate to next suit
         */
        if(isSuitSpace) {
            player.GrantSuit(currentSuit);
            if(isRotatingSuit) {
                RotateSuit();
            }
        }
    }

    private void RotateSuit() {
        switch (currentSuit) {
            case Suit.Spade: currentSuit = Suit.Heart; break;
            case Suit.Heart: currentSuit = Suit.Diamond; break;
            case Suit.Diamond: currentSuit = Suit.Club; break;
            case Suit.Club: currentSuit = Suit.Spade; break;
        }
    }
}

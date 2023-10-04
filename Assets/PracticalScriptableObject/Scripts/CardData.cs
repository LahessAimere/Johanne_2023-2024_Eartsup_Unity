using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "new_CardData", menuName = "ScriptableObjects/new CardData")]
public class CardData : ScriptableObject
{
   private enum CardValue 
   {
       Two, 
       Three, 
       Four, 
       Five, 
       Six, 
       Seven, 
       Height,
       Nine,
       Ten,
       Jack,
       Queen,
       King,
       Ace 
   }

   private enum CardColor
    {
        Clover,
        Spade,
        Tile,
        Heart
    }
   
   [SerializeField] private CardValue _cardValue;
   [SerializeField] private CardColor _cardColor;
   
   public override string ToString()
   {
       return _cardValue.ToString() + " " + _cardColor.ToString();
   }
}

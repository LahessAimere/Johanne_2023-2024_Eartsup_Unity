using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_CardDeckData", menuName = "ScriptableObjects/new CardDeckData")]
public class CardDeckData : ScriptableObject
{
    [SerializeField] private CardData[] _cardDataArray; 
    public CardData[] CardDataArray => _cardDataArray;
}

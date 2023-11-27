using System.Collections.Generic;
using UnityEngine;

public class CardDeckData : ScriptableObject
{
    [SerializeField] private List<CardData> _cardDataList;
    public List<CardData> CardDataList => _cardDataList;
}
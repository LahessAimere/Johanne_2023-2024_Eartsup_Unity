using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

    
public class CardDeckData : ScriptableObject
{
    [SerializeField] private List<CardData> _cardDataList;
    public List<CardData> CardDataList => _cardDataList;
}

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CardDeckData : ScriptableObject
{
    [SerializeField] private List<CardData> _cardDataList;
    public List<CardData> CardDataList => _cardDataList;

    private string[] _cardDataListPath;

    private void OnEnable()
    {
        _cardDataList.Clear();
        _cardDataListPath = AssetDatabase.FindAssets("t:CardData");
        foreach (string cardDataListPath in _cardDataListPath)
        {
            _cardDataList.Add(AssetDatabase.LoadAssetAtPath<CardData>(AssetDatabase.GUIDToAssetPath(cardDataListPath)));
        }
    }
}
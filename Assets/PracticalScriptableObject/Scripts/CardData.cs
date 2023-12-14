using System;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "new_CardData", menuName = "ScriptableObjects/new CardData")]
public class CardData : ScriptableObject
{
    [SerializeField] private Kind _cardColor;
    public Kind CardValue
    {
        get => _cardColor;
        set => _cardColor = value;
    } 
    [SerializeField] private Suit _cardValue;
    public Suit CardColor
    {
        get => _cardValue;
        set => _cardValue = value;
    }

    public enum Kind
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

    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades,
    }
    
    private CardData[] _cardDatas;

    [MenuItem("CardGenerate/Deck")]
    private static void DeckGenerate()
    {
        AssetDatabase.DeleteAsset("Assets/PracticalScriptableObject/Deck");
        AssetDatabase.CreateFolder("Assets/PracticalScriptableObject", "Deck");
        
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            AssetDatabase.CreateFolder("Assets/PracticalScriptableObject/Deck", suit.ToString());
            foreach (Kind kind in Enum.GetValues(typeof(Kind)))
            {
                CardData newCardAsset = ScriptableObject.CreateInstance<CardData>();
                newCardAsset._cardColor = kind;
                newCardAsset._cardValue = suit;
                AssetDatabase.CreateAsset(newCardAsset,
                    "Assets/PracticalScriptableObject/Deck/" + suit.ToString() + "/" + suit.ToString() + "_" + kind +
                    ".asset");
            }
        }
    }
}
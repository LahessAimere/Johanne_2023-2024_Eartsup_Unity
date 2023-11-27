using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSevenCards : MonoBehaviour
{
    [SerializeField] private List<CardData> _cardDataList;
    private void Start()
    {
        _cardDataList = new List<CardData>();
        ChooseDeck();
    }
    private void ChooseDeck()
    {
        //Fill the deck with all 52 cards
        foreach (CardData.Kind kind in Enum.GetValues(typeof(CardData.Kind)))
        {
            foreach (CardData.Suit suit in Enum.GetValues(typeof(CardData.Suit)))
            {
                CardData cardData = ScriptableObject.CreateInstance<CardData>();
                cardData.CardValue = kind;
                cardData.CardColor = suit;

                _cardDataList.Add(cardData);
            }
        }
        
        //List for the 7 card deck
        List<CardData> deck = new List<CardData>();
        
        //Draw the 7 cards
        while (deck.Count < 7)
        {
            //Select a random index in the deck
            int index = Random.Range(0, deck.Count);
            //Retrieve the card at this index
            CardData cardData = _cardDataList[index];
            
            //Checks if the card is in the deck
            if (!deck.Contains(cardData))
            {
                deck.Add(cardData);
                _cardDataList.RemoveAt(index);
            }
        }

        foreach (CardData cardData in deck)
        {
            Debug.Log($"{cardData.CardColor} of {cardData.CardValue}");
        }
    }
}
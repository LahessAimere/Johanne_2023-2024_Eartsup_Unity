using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSevenCards : MonoBehaviour
{
    [SerializeField] private List<CardData> _sevenCards;
    [SerializeField] private int _numberOfCardsDeck;
    [SerializeField] private CardDeckData _cardDeckData;
    private void Start()
    {
        List<CardData> deck = new List<CardData>(_cardDeckData.CardDataList);
        for (int numberOfCard = 0; numberOfCard < _numberOfCardsDeck; numberOfCard++)
        {
            int pick = Random.Range(0, deck.Count);
            _sevenCards.Add(deck[pick]);
            deck.RemoveAt(pick);
        }
        foreach (CardData card in _sevenCards)
        {
            Debug.Log(card);
        }
    }
}
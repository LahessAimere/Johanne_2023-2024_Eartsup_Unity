using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class RandomSevenCards : MonoBehaviour
{
    [SerializeField] private CardDeckData _cardDeckData;
    [SerializeField] private CardData[] _cardDatas;
   

    private void Start()
    {
        _cardDatas = new CardData[7];
        
        for (int i = 0; i < _cardDatas.Length; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, _cardDeckData.CardDataArray.Length);
            _cardDatas[i] = _cardDeckData.CardDataArray[randomIndex];
            
            Debug.Log(_cardDatas[i]);
        }
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "new_CardData", menuName = "ScriptableObjects/new CardData")]
public class CardData : ScriptableObject
{
    private Kind _cardValue;
    private Suit _cardColor; 
    public Kind CardValue
    {
        get => _cardValue;
        set => _cardValue = value;
    } 
    public Suit CardColor
    {
        get => _cardColor;
        set => _cardColor = value;
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
}
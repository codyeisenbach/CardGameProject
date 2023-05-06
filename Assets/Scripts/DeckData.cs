using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;


[CreateAssetMenu(fileName = "DeckData", menuName = "Card Game/Deck Data")]
public class DeckData : ScriptableObject
{
    public AssetLabelReference[] labelsToInclude;

    private List<CardData> cards; //the deck of actual cards, needs to be shuffled
    private List<CardData> discardedCards;
    private CardData cardStore;
    private int currentCard = 0;

    private void Awake()
    {
        discardedCards.RemoveRange(0, discardedCards.Count);
    }

    public void CardsRetrieved(List<CardData> cardDataDownloaded)
    {
        //load the actual cards data into an array, ready to use
        int totalCards = cardDataDownloaded.Count;

        cards = new List<CardData>();
        for (int c = 0; c < totalCards; c++)
        {
            cards.Add(cardDataDownloaded[c]);
        }
    }

    public void ShuffleCards()
    {

        for (int i = 0; i < cards.Count; i++)
        {
            int randomIndex = UnityEngine.Random.Range(i, cards.Count);
            CardData temp = cards[randomIndex];
            cards[randomIndex] = cards[i];
            cards[i] = temp;
        }
    }

    //returns the next card in the deck.
    public CardData GetNextCardFromDeck()
    {
        if (currentCard <= 0)
            ShuffleCards();

        currentCard++;
        if (currentCard >= cards.Count)
        {
            currentCard = 0;
        }

        cardStore = cards[currentCard];
        discardedCards.Add(cardStore);
        cards.Remove(cardStore);

        return cardStore;
    }

    public void RefillDeck()
    {
        cards.AddRange(discardedCards);
        discardedCards.RemoveRange(0, discardedCards.Count);
        ShuffleCards();
    }
}


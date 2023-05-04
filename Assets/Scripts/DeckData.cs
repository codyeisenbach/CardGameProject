using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;


[CreateAssetMenu(fileName = "DeckData", menuName = "Card Game/Deck Data")]
public class DeckData : ScriptableObject
{
    public AssetLabelReference[] labelsToInclude;

    private CardData[] cards; //the deck of actual cards, needs to be shuffled
    private int currentCard = 0;

    public void CardsRetrieved(List<CardData> cardDataDownloaded)
    {
        //load the actual cards data into an array, ready to use
        int totalCards = cardDataDownloaded.Count;

        Debug.Log("cardDataDownloaded: " + cardDataDownloaded);
        cards = new CardData[totalCards];
        for (int c = 0; c < totalCards; c++)
        {
            cards[c] = cardDataDownloaded[c];
        }
    }

    public void ShuffleCards()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            int randomIndex = UnityEngine.Random.Range(i, cards.Length);
            CardData temp = cards[randomIndex];
            cards[randomIndex] = cards[i];
            cards[i] = temp;
        }

        //TODO: shuffle cards
    }

    //returns the next card in the deck. You probably want to shuffle cards first
    public CardData GetNextCardFromDeck()
    {
        ShuffleCards();

        //advance the index
        currentCard++;
        if (currentCard >= cards.Length)
            currentCard = 0;

        Debug.Log("cards[currentCard]: " + cards[currentCard]);

        return cards[currentCard];
    }
}


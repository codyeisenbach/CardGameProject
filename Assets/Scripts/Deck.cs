using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{

    public enum CardSuits
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public int[] CardRanks =
    {
        1,
        2,
        3,
        4,
        5,
        6,
        7,
        8,
        9,
        10,
        11,
        12,
        13
    };

    string[] rankKeys = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    string cardName;
    Sprite newSprite;
    public GameObject CardDeck;
    public GameObject DiscardPile;
    public GameObject Card;

    public List<GameObject> newDeck = new List<GameObject>();
    public List<GameObject> discardPile = new List<GameObject>();

    void Start()
    {
        //ShuffleDeck();
        //int suitNumber = CardSuits.GetNames(typeof(CardSuits)).Length;

        //int rankNumber = CardRanks.Length;

        //for (int i = 0; i < suitNumber; i++)
        //{

        //    for (int j = 0; j < rankNumber; j++)
        //    {
        //        cardName = "";
        //        cardName += "card" + ((CardSuits)i).ToString() + rankKeys[j];

        //        string cardSuit = CardSuits.GetNames(typeof(CardSuits))[i];

        //        int cardRank = CardRanks[j];


        //        newSprite = Resources.Load<Sprite>(cardName);

        //        GameObject cardObject = Instantiate(Card, transform.position, transform.rotation);
        //        cardObject.name = cardName;
        //        Card cardComponent = cardObject.GetComponent<Card>();
        //        cardObject.transform.SetParent(CardDeck.transform);
        //        cardObject.AddComponent<SpriteRenderer>();
        //        cardObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        //        cardComponent.suit = cardSuit;
        //        cardComponent.rank = cardRank;
        //        cardComponent.isFaceUp = false;


        //        newDeck.Add(cardObject);
        //    }
        //}
    }

    public void AddToDiscardPile(GameObject card)
    {

        discardPile.Add(card);


    }

    public void ShuffleDeck()
    {

        // Destroy active cards
        GameObject playerArea = GameObject.Find("PlayerArea");
        GameObject dropZone = GameObject.Find("DropZone");

        int playerAreaCount = playerArea.transform.childCount;
        Debug.Log(playerAreaCount);
        int dropZoneCount = dropZone.transform.childCount;

        int activeCardCount = playerAreaCount + dropZoneCount;

        if (activeCardCount >= 1)
        {
            for (int j = 0; j < playerAreaCount; j++)
            {
                GameObject.Destroy(playerArea.transform.GetChild(j).gameObject);
            }
            for (int j = 0; j < dropZoneCount; j++)
            {
                GameObject.Destroy(dropZone.transform.GetChild(j).gameObject);
            }
        }

        // Add in Discard Pile
        GameObject CardDeck = GameObject.Find("CardDeck");
        GameObject DiscardPile = GameObject.Find("DiscardPile");

        int discardChildCount = DiscardPile.transform.childCount;

        for (int i = 0; i < discardChildCount; i++)
        {
            GameObject childObj = DiscardPile.transform.GetChild(i).gameObject;
            GameObject newGameObject = Instantiate(childObj);
            newGameObject.transform.parent = CardDeck.transform;
            Destroy(childObj);
        }


        // Shuffle
        int childCount = CardDeck.transform.childCount;

        Transform[] childObjects = new Transform[childCount];

        for (int i = 0; i < childCount; i++)
        {
            childObjects[i] = CardDeck.transform.GetChild(i);
        }

        for (int i = 0; i < childCount - 1; i++)
        {
            int randomIndex = UnityEngine.Random.Range(i, childCount);

            if (randomIndex != i)
            {
                Transform temp = childObjects[i];
                childObjects[i] = childObjects[randomIndex];
                childObjects[randomIndex] = temp;
            }
        }

        for (int i = 0; i < childCount; i++)
        {
            childObjects[i].SetSiblingIndex(i);
        }
    }
}

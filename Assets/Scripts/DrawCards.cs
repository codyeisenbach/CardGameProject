using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DrawCards : MonoBehaviour
{
    public Deck Deck;
    public GameObject Card;
    public GameObject CardDeck;
    public GameObject DiscardPile;
    public GameObject PlayerArea;
    public GameObject EnemyArea;

    private int handSize = 5;


    public void OnClick()
    {
        GameObject playerArea = GameObject.Find("PlayerArea");
        GameObject dropZone = GameObject.Find("DropZone");

        int playerAreaCount = playerArea.transform.childCount;
        Debug.Log(playerAreaCount);
        int dropZoneCount = dropZone.transform.childCount;

        int childCount = playerAreaCount + dropZoneCount;

        if (childCount >= 1)
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

        // Show the players hand
        for (int i = 0; i < handSize; i++)
        {
            string playerCardName = "playerCard" + 1;

            GameObject DeckCard = CardDeck.transform.GetChild(UnityEngine.Random.Range(0, childCount)).gameObject;


            GameObject discardPile = GameObject.Find("DiscardPile");

            // Set playerCard to playerArea
            GameObject playerCard = Instantiate(DeckCard, new Vector2(0, 0), Quaternion.identity);

            playerCard.transform.SetParent(PlayerArea.transform, false);

            // Place last hand in discard pile
            DeckCard.transform.SetParent(CardDeck.transform);

            DeckCard.transform.SetParent(discardPile.transform);

        }
    }
}

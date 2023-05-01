using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DrawCards : MonoBehaviour
{
    //public Deck Deck;
    public GameObject card;
    public GameObject cardDeck;
    public GameObject discardPile;
    public GameObject playerArea;
    public GameObject dropZone;
    public GameObject enemyArea;

    private int playedCount;
    private GameObject playerCard;
    private int handSize = 5;


    public void OnClick()
    {
        playedCount = playedCount + handSize;
        int playerAreaCount = playerArea.transform.childCount;
        Debug.Log(playerAreaCount);
        int dropZoneCount = dropZone.transform.childCount;

        int childCount = playerAreaCount + dropZoneCount;

        int cardsLeft = 52 - playedCount;

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

            GameObject newCard = cardDeck.transform.GetChild(UnityEngine.Random.Range(0, cardsLeft)).gameObject;

            // Set playerCard to playerArea
            playerCard = Instantiate(newCard, new Vector2(0, 0), Quaternion.identity);

            playerCard.transform.position = new Vector2(0, 0);
            playerCard.transform.rotation = Quaternion.identity;
            playerCard.transform.SetParent(playerArea.transform, false);

            Sprite playerSprite = playerCard.GetComponent<SpriteRenderer>().sprite;

            playerCard.GetComponent<Image>().sprite = playerSprite;


            // Place last hand in discard pile
            newCard.transform.SetParent(cardDeck.transform);

            newCard.transform.SetParent(discardPile.transform);

        }
    }
}

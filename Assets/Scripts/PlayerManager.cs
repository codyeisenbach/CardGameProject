using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using System;
using System.Linq;

public class PlayerManager : NetworkBehaviour
{
    public GameObject Deck;
    public GameObject Card;
    public GameObject CardDeck;
    public GameObject playerCard;
    public GameObject PlayerArea;
    public GameObject EnemyArea;
    public GameObject DropZone;

    public int handSize = 5;

    [SyncVar]
    int cardsPlayed = 0;

    public override void OnStartClient()
    {
        base.OnStartClient();

        PlayerArea = GameObject.Find("PlayerArea");
        EnemyArea = GameObject.Find("EnemyArea");
        DropZone = GameObject.Find("DropZone");
    }



    [Server]
    public override void OnStartServer()
    {

        Instantiate(Deck, new Vector2(0, 0), Quaternion.identity);

    }



    [Command]
    public void CmdDealCards()
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

    //public void PlayCard(GameObject card)
    //{
    //    CmdPlayCard(card);
    //    cardsPlayed++;
    //    //Debug.Log(cardsPlayed);
    //}

    //[Command]
    //void CmdPlayCard(GameObject card)
    //{
    //    RpcShowCard(card, "Played");
    //}

    //[ClientRpc]
    //void RpcShowCard(GameObject card, string type)
    //{
    //    if (type == "Dealt")
    //    {

    //        if (isOwned)
    //        {
    //            Debug.Log(card.name);
    //            card.transform.SetParent(PlayerArea.transform, false);
    //            card.GetComponent<CardFlipper>().Flip();
    //        }
    //        else if (!isOwned)
    //        {
    //            card.transform.SetParent(EnemyArea.transform, false);
    //        }


    //    }
    //    else if (type == "Played")
    //    {
    //        card.transform.SetParent(DropZone.transform, false);
    //        if (!isOwned)
    //        {
    //            card.GetComponent<CardFlipper>().Flip();
    //        }
    //    }
    //}
}


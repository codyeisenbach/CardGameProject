using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using Unity.VisualScripting;

public class CardManager : MonoBehaviour
    {
        public DeckData playersDeck;
        public GameObject playerManager;
        public GameObject cardPrefab;
        public GameObject activeCard;
        public GameObject playerArea;
        Card[] cards;


        private void Awake()
        {
            cards = new Card[2]; // Draw 2 cards
            LoadDeck();
        }

        public void LoadDeck()
        {
            DeckLoader newDeckLoaderComp = gameObject.AddComponent<DeckLoader>();
            newDeckLoaderComp.OnDeckLoaded += DeckLoaded;
            newDeckLoaderComp.LoadDeck(playersDeck);
            playersDeck.RefillDeck();

    }

    private void DeckLoaded()
        {
            Debug.Log("Deck loaded");
            //setup initial cards
            for (int i = 0; i < cards.Length; i++)
            {
                StartCoroutine(AddCardToDeck());
            }
        }

        //adds a new card to the deck
        private IEnumerator AddCardToDeck(float delay = 0.01f) //TODO: pass in the CardData dynamically
        {
            // Staggers card creation
            yield return new WaitForSeconds(delay);

            //create new card
            activeCard = Instantiate<GameObject>(cardPrefab, playerArea.transform);


            //populate CardData on the Card script
            Card cardScript = activeCard.GetComponent<Card>();
            cardScript.InitialiseWithData(playersDeck.GetNextCardFromDeck());

            GetScore();
        }

        public void DrawCard()
        {
            PlayerManager playerComponent = playerManager.GetComponent<PlayerManager>();
        if (playerComponent.scoreValue >= playerComponent.losingValue)
        {
            ShuffleDeck();
            LoadDeck();
        }
        else
            StartCoroutine(AddCardToDeck(.5f));
        }

        public void ShuffleDeck()
        {
            playersDeck.RefillDeck();
            EmptyPlayerHand();
        }

        public void GetScore()
        {
            PlayerManager playerComponent = playerManager.GetComponent<PlayerManager>();
            playerComponent.ShowScore();
            playerComponent.CheckForLoss();
            playerComponent.CheckForWin();
    }

        public void EmptyPlayerHand()
        {
            for (int i = 0; i < playerArea.transform.childCount; i++)
            {
                Destroy(playerArea.transform.GetChild(i).gameObject);
            }
        }

}

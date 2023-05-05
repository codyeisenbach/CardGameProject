using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using Unity.VisualScripting;

public class CardManager : MonoBehaviour
    {
        public DeckData playersDeck;
        public GameObject cardPrefab;
        public GameObject activeCard;
        public GameObject playerArea;
        Transform playerAreaTransform;

        Card[] cards;

        private void Awake()
        {
            cards = new Card[1]; // Draw 2 cards
            LoadDeck();
        }

        public void LoadDeck()
        {
            DeckLoader newDeckLoaderComp = gameObject.AddComponent<DeckLoader>();
            newDeckLoaderComp.OnDeckLoaded += DeckLoaded;
            newDeckLoaderComp.LoadDeck(playersDeck);
            playersDeck.EmptyDiscarded();
        }

    private void DeckLoaded()
        {
            Debug.Log("Player's deck loaded");
            //setup initial cards
            StartCoroutine(AddCardToDeck(.1f));
            for (int i = 0; i < cards.Length; i++)
            {
                StartCoroutine(AddCardToDeck(.8f + i));
            }
        }

    //adds a new card to the deck
        private IEnumerator AddCardToDeck(float delay = 0.2f) //TODO: pass in the CardData dynamically
        {

        // Staggers card creation
        yield return new WaitForSeconds(delay);

        playerAreaTransform = playerArea.transform;

        //create new card
        activeCard = Instantiate<GameObject>(cardPrefab, playerAreaTransform);


            //populate CardData on the Card script
            Card cardScript = activeCard.GetComponent<Card>();
            cardScript.InitialiseWithData(playersDeck.GetNextCardFromDeck());
        }

        public void DrawCard()
        {

        if (playerArea.transform.childCount >= 52)
            {
            EmptyPlayerHand();
            playersDeck.RefillDeck();
        }

            StartCoroutine(AddCardToDeck(.1f));
        }

        public void EmptyPlayerHand()
        {
            for (int i = 0; i < playerArea.transform.childCount; i++)
            {
                Destroy(playerArea.transform.GetChild(i).gameObject);
            }
        }
    }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

    public class CardManager : MonoBehaviour
    {
        public DeckData playersDeck;
        public GameObject cardPrefab;
        public GameObject activeCard;
        public GameObject playerArea;
        public GameObject cardDeck;

        Transform cardDeckTransform;

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
        }

        //...

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
        cardDeckTransform = cardDeck.transform;

        //create new card
        activeCard = Instantiate<GameObject>(cardPrefab, cardDeckTransform);


            //populate CardData on the Card script
            Card cardScript = activeCard.GetComponent<Card>();
            cardScript.InitialiseWithData(playersDeck.GetNextCardFromDeck());
        }
    }

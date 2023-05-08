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
        bool hasShuffled = false;


    private void Awake()
        {
            cards = new Card[2]; // Draw 2 cards
            LoadDeck();
        }

        public void LoadDeck()
        {
            Debug.Log("DrawCard Player Hand Length before: " + cards.Length);
            DeckLoader newDeckLoaderComp = gameObject.AddComponent<DeckLoader>();
            newDeckLoaderComp.OnDeckLoaded += DeckLoaded;
            newDeckLoaderComp.LoadDeck(playersDeck);
            Debug.Log("DrawCard Player Hand Length after: " + cards.Length);
        }

        private void DeckLoaded()
        {
            playersDeck.EmptyDiscarded();
            //setup initial cards
            for (int i = 0; i < cards.Length; i++)
            {
                StartCoroutine(AddCardToDeck());
            }

        //Debug.Log("DeckLoaded Player Hand: " + cards.Length);
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
            Debug.Log("hasShuffled: " + hasShuffled);
            PlayerManager playerComponent = playerManager.GetComponent<PlayerManager>();
            if (playerComponent.scoreValue >= playerComponent.losingValue || playerComponent.scoreValue == playerComponent.winningValue || hasShuffled == true)
            {
            //ShuffleDeck();
            playersDeck.RefillDeck();
            EmptyPlayerHand();
            LoadDeck();
            }
            else if (playerComponent.scoreValue < 21)
                StartCoroutine(AddCardToDeck());

            Debug.Log("DrawCard Player Hand Length: " + cards.Length);

            hasShuffled = false;
    }

    public void ShuffleDeck()
        {
            playersDeck.RefillDeck();
            playersDeck.ShuffleCards();
            EmptyPlayerHand();
            hasShuffled = true;
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

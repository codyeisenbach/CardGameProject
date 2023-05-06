using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;


    public class Card : MonoBehaviour
    {
        [HideInInspector] public CardData cardData;

        public Image cardDataImage;
        public string cardDataName;
        public string cardDataRank;
        public int cardDataValue;

    //called by CardManager, it feeds CardData so this card can display an image.
    public void InitialiseWithData(CardData cData)
        {
        cardData = cData;
        cardDataImage.sprite = cardData.cardImage;
        cardDataName = cardData.cardName;
        cardDataValue = cardData.cardValue;
        cardDataRank = cardData.cardRank;
    }

    }

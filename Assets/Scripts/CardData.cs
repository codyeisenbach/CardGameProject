using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(fileName = "CardData", menuName = "Card Game/Card Data")]
    public class CardData : ScriptableObject
    {
        [Header("Card graphics")]
        public Sprite cardImage;

        [Header("Card name")]
        public string cardName;

        [Header("Card rank")]
        public string cardRank;

        [Header("Card value")]
        public int cardValue;
}

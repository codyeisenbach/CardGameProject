using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;


    public class Card : MonoBehaviour
    {
        [HideInInspector] public CardData cardData;

        public Image cDataImage;

        //called by CardManager, it feeds CardData so this card can display an image.
        public void InitialiseWithData(CardData cData)
        {
        Debug.Log("InitializeWithData Fired: " + cData);
            cardData = cData;
        Debug.Log("cardData.cardImage: " + cardData.cardImage);
            cDataImage.sprite = cardData.cardImage;
        }

        //public void OnPointerDown(PointerEventData pointerEvent)
        //{
        //    if (OnTapDownAction != null)
        //        OnTapDownAction(cardId);
        //}

        //public void OnDrag(PointerEventData pointerEvent)
        //{
        //    if (OnDragAction != null)
        //        OnDragAction(cardId, pointerEvent.delta);
        //}

        //public void OnPointerUp(PointerEventData pointerEvent)
        //{
        //    if (OnTapReleaseAction != null)
        //        OnTapReleaseAction(cardId);
        //}

    }

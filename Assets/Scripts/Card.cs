using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public string suit;
    public int rank;
    public bool isFaceUp;

    private SpriteRenderer spriteRenderer;

    public Card(string cardName)
    {
        GameObject newGameObj = new GameObject(cardName);
    }

    void Start()
    {

       
        gameObject.AddComponent<Image>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set the card's sprite based on its rank and suit
        string spriteName = GetSpriteName();
        Sprite sprite = Resources.Load<Sprite>(spriteName);
        spriteRenderer.sprite = sprite;

        transform.position = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.identity;

        isFaceUp = true;
        SetFaceUp(isFaceUp);
    }

    private string GetSpriteName()
    {
        string spriteName = "card";

        // Get the suit of the card
        switch (suit)
        {
            case "Clubs":
                spriteName += "Clubs";
                break;
            case "Diamonds":
                spriteName += "Diamonds";
                break;
            case "Hearts":
                spriteName += "Hearts";
                break;
            case "Spades":
                spriteName += "Spades";
                break;
        }

        // Get the rank of the card
        switch (rank)
        {
            case 1:
                spriteName += "A";
                break;
            case 11:
                spriteName += "J";
                break;
            case 12:
                spriteName += "Q";
                break;
            case 13:
                spriteName += "K";
                break;
            default:
                spriteName += rank.ToString();
                break;
        }

        return spriteName;
    }

            
    // Method to set the card to face up or face down
    public void SetFaceUp(bool faceUp)
    {
        isFaceUp = faceUp;
        if (isFaceUp)
        {
            Sprite cardFront = Resources.Load<Sprite>(GetSpriteName());
            gameObject.GetComponent<Image>().sprite = cardFront;
        }
        else
        {
            Sprite cardBack = Resources.Load<Sprite>("cardBack_blue2");
            gameObject.GetComponent<Image>().sprite = cardBack;
        }
    }
}




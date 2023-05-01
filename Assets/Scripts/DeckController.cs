using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DeckController : MonoBehaviour
{

    public GameObject cardDeck;
    public GameObject discardPile;
    public GameObject card;
    public GameObject playerArea;
    public GameObject dropZone;

    void Start()
    {
        ShuffleDeck();
    }

    public void AddToDiscardPile(GameObject card)
    {

        card.transform.SetParent(playerArea.transform, false);

    }

    public void ShuffleDeck()
    {

        // Destroy active cards

        int playerAreaCount = playerArea.transform.childCount;

        int dropZoneCount = dropZone.transform.childCount;

        int activeCardCount = playerAreaCount + dropZoneCount;

        if (activeCardCount >= 1)
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

        // Add in Discard Pile


        int discardChildCount = discardPile.transform.childCount;

        for (int i = 0; i < discardChildCount; i++)
        {
            GameObject childObj = discardPile.transform.GetChild(i).gameObject;
            GameObject newGameObject = Instantiate(childObj);
            newGameObject.transform.parent = cardDeck.transform;
            Destroy(childObj);
        }


        // Shuffle
        int childCount = cardDeck.transform.childCount;

        Transform[] childObjects = new Transform[childCount];

        for (int i = 0; i < childCount; i++)
        {
            childObjects[i] = cardDeck.transform.GetChild(i);
        }

        for (int i = 0; i < childCount - 1; i++)
        {
            int randomIndex = UnityEngine.Random.Range(i, childCount);

            if (randomIndex != i)
            {
                Transform temp = childObjects[i];
                childObjects[i] = childObjects[randomIndex];
                childObjects[randomIndex] = temp;
            }
        }

        for (int i = 0; i < childCount; i++)
        {
            childObjects[i].SetSiblingIndex(i);
        }
    }
}

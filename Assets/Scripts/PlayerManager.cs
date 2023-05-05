using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using Unity.VisualScripting;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public DeckData playersDeck;
    public GameObject playerScore;
    public GameObject playerArea;

    private int scoreValue;

    private string score;

    private void GetPlayerScore()
    {
        scoreValue = 0;
        for (int i = 0; i < playerArea.transform.childCount; i++)
        {
            Card currentChild = playerArea.transform.GetChild(i).GetComponent<Card>();
            scoreValue = scoreValue + currentChild.cardDataValue;
        }

        score = scoreValue.ToString();
    }

    private void Update()
    {
        //GetPlayerScore();
        //ShowScore();
    }


    public void ShowScore()
    {
        GetPlayerScore();

        playerScore.GetComponent<Text>().text = "Player Score: " + score;
    }
}

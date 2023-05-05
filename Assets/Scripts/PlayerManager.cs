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
    public int losingValue = 21;

    private int scoreValue;
    private string score;

    private int GetPlayerScore()
    {
        scoreValue = 0;
        for (int i = 0; i < playerArea.transform.childCount; i++)
        {
            Card currentChild = playerArea.transform.GetChild(i).GetComponent<Card>();
            scoreValue = scoreValue + currentChild.cardDataValue;
        }

        score = scoreValue.ToString();

        return scoreValue;
    }

    public void ShowScore()
    {
        GetPlayerScore();

        playerScore.GetComponent<Text>().text = "Player Score: " + score;
    }

    public void ShowLosingText()
    {
        GetPlayerScore();

        playerScore.GetComponent<Text>().text = "Player Score: " + score + "  Bust!";
    }

    public void CheckForLoss()
    {
        if (GetPlayerScore() > losingValue)
        {
            ShowLosingText();
        }
    }
}

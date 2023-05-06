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
    public int losingValue = 22;
    public int winningValue = 21;
    public int scoreValue = 0;

    private int aceCount = 0;
    private string score;


    private int GetPlayerScore()
    {
        scoreValue = 0;
        for (int i = 0; i < playerArea.transform.childCount; i++)
        {
            Card currentChild = playerArea.transform.GetChild(i).GetComponent<Card>();
            string currentRank = currentChild.cardDataRank;
            int currentValue = currentChild.cardDataValue;
            scoreValue = scoreValue + currentValue;

            if (currentRank == "A")
            {
                aceCount++;
            }


        }
            for (int j = 0; j < aceCount; j++)
            {
                int aceValue1 = 21 - (scoreValue + 1);
                int aceValue11 = 21 - (scoreValue + 11);

            if (aceValue11 < aceValue1)
                scoreValue = scoreValue + 10;
                score = scoreValue.ToString();
                return scoreValue;
            }

        score = scoreValue.ToString();
        return scoreValue;
    }

    public void ShowScore()
    {
        GetPlayerScore();
        playerScore.GetComponent<Text>().text = "Player Score: " + score;
    }

    public void CheckForLoss()
    {
        if (GetPlayerScore() >= losingValue)
        {
            ShowLosingText();
        }
    }

    public void CheckForWin()
    {
        if (GetPlayerScore() == winningValue)
        {
            ShowWinningText();
        }
    }

    public void ShowLosingText()
    {
        GetPlayerScore();
        playerScore.GetComponent<Text>().text = "Player Score: " + score + "  Bust!";
    }

    public void ShowWinningText()
    {
        GetPlayerScore();
        playerScore.GetComponent<Text>().text = "Player Score: " + score + "  You Win!";
    }
}

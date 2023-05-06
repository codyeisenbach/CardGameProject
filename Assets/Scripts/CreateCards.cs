using UnityEngine;
using UnityEditor;
using static CreateCards;
using static UnityEngine.RuleTile.TilingRuleOutput;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Card Game/Create Cards")]
public class CreateCards : ScriptableObject
{

    string cardName = "";
    string[] cardSuits =
        {"Hearts",
        "Diamonds",
        "Clubs",
        "Spades"};

    Dictionary<string, int> cardValues = new Dictionary<string, int>()
    {
        {"A", 1},
        {"2", 2},
        {"3", 3},
        {"4", 4},
        {"5", 5},
        {"6", 6},
        {"7", 7},
        {"8", 8},
        {"9", 9},
        {"10", 10},
        {"J", 10},
        {"Q", 10},
        {"K", 10}
    };

    void Awake()
    {

            for (int i = 0; i < cardSuits.Length; i++)
            {
                foreach (KeyValuePair<string, int> cardValue in cardValues)
                {
                    cardName += "card" + (cardSuits[i]) + cardValue.Key;
                    string path = "Assets/Sprites/" + cardName + ".png";

                    // Create a new Card Scriptable Object
                    CardData card = ScriptableObject.CreateInstance<CardData>();

                    Debug.Log(path);

                    // Assign Sprites
                    Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(path);

                    // Set the name and image of the Card Scriptable Object
                    card.cardName = cardName;
                    card.name = cardName;
                    card.cardValue = cardValue.Value;
                    card.cardRank = cardValue.Key;
                    card.cardImage = sprite;

                    AssetDatabase.CreateAsset(card, "Assets/GameData/Cards/" + cardName + ".asset");

                    // Save the changes to the Card Scriptable Object asset
                    EditorUtility.SetDirty(card);
                    AssetDatabase.SaveAssets();
                    cardName = "";
                    path = "";

                }
            }
    }
}

using UnityEngine;
using UnityEditor;
using static CreateCards;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(menuName = "Card Game/Create Cards")]
public class CreateCards : ScriptableObject
{

    string cardName = "";
    string[] cardSuits =
        {"Hearts",
        "Diamonds",
        "Clubs",
        "Spades"};

    string[] cardRanks = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    Sprite[] cardImages; // Array of card images to assign to the Card Scriptable Objects

    void Awake()
    {

            for (int i = 0; i < cardSuits.Length; i++)
            {
                for (int j = 0; j < cardRanks.Length; j++)
                {
                    cardName += "card" + (cardSuits[i]) + cardRanks[j];
                    string path = "Assets/Sprites/" + cardName + ".png";

                    // Create a new Card Scriptable Object
                    CardData card = ScriptableObject.CreateInstance<CardData>();

                    Debug.Log(path);

                    // Assign Sprites
                    Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(path);

                    // Set the name and image of the Card Scriptable Object
                    card.cardName = cardName;
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

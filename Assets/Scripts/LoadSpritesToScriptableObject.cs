using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadSpritesToScriptableObject : MonoBehaviour
{
    [SerializeField] private SpritesData spritesData;
    [SerializeField] private List<string> spriteAddresses;
    private string[] rankKeys = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    private string address;
    public enum CardSuits
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public int[] CardRanks =
    {
        1,
        2,
        3,
        4,
        5,
        6,
        7,
        8,
        9,
        10,
        11,
        12,
        13
    };

    private List<AsyncOperationHandle<Sprite>> handles = new List<AsyncOperationHandle<Sprite>>();

    private void Start()
    {
        GetSpriteAddresses();
        if (spritesData == null || spriteAddresses.Count == 0)
        {
            Debug.LogError("SpritesData or SpriteAddresses are not assigned");
            return;
        }

        spritesData.sprites = new List<Sprite>();

        foreach (string address in spriteAddresses)
        {
            AsyncOperationHandle<Sprite> handle = Addressables.LoadAssetAsync<Sprite>(address);
            handle.Completed += OnSpriteLoaded;
            handles.Add(handle);
        }
    }

    private void OnSpriteLoaded(AsyncOperationHandle<Sprite> operation)
    {
        if (operation.Status == AsyncOperationStatus.Succeeded)
        {
            spritesData.sprites.Add(operation.Result);
            Debug.Log("Sprite loaded into ScriptableObject");
        }
        else
        {
            Debug.LogError("Failed to load sprite");
        }
    }

    private void OnDestroy()
    {
        foreach (AsyncOperationHandle<Sprite> handle in handles)
        {
            if (handle.IsValid())
            {
                Addressables.Release(handle);
            }
        }
    }

    private void GetSpriteAddresses()
    {

        int suitNumber = CardSuits.GetNames(typeof(CardSuits)).Length;

        int rankNumber = CardRanks.Length;

        for (int i = 0; i < suitNumber; i++)
        {
            for (int j = 0; j < rankNumber; j++)
            {

                string cardName = "card" + ((CardSuits)i).ToString() + rankKeys[j];

                address = $"Assets/Sprites/{cardName}.png";

                spriteAddresses.Add(address);
                foreach (string str in spriteAddresses)
                {
                Debug.Log($"spriteAddresses {str}");
            
                }

            }
        }
    }
}

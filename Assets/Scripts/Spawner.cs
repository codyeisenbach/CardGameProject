using System.Collections;
using System.Collections.Generic;
using UnityEditor.AddressableAssets.Build.Layout;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Spawner : MonoBehaviour
{


    private Transform entityTranform;
    private Transform parentTransform;
    private string[] rankKeys = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    private string cardName;

    public GameObject entityToSpawn;
    public ScriptableCard spawnManagerValues;
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



//using UnityEngine;
//using UnityEngine.AddressableAssets;
//using UnityEngine.ResourceManagement.AsyncOperations;

//public class YourClass : MonoBehaviour
//{
//    public MyScriptableObject scriptableObject;

//    public void LoadAddressableIntoScriptableObject()
//    {
//        AsyncOperationHandle<MyAssetType> loadHandle = Addressables.LoadAssetAsync<MyAssetType>(scriptableObject.addressableAsset);
//        loadHandle.Completed += OnAssetLoaded;
//    }

//    private void OnAssetLoaded(AsyncOperationHandle<MyAssetType> loadHandle)
//    {
//        if (loadHandle.Status == AsyncOperationStatus.Succeeded)
//        {
//            MyAssetType loadedAsset = loadHandle.Result;
//            // Do something with the loaded asset...
//        }
//    }
//}




void Start()
    {
    Debug.Log($"spawnManagerValues: {spawnManagerValues.parentObject}");
        SpawnEntities();
    }

    void SpawnEntities()
    {
        int currentSpawnPointIndex = 0;

        GameObject parentEntity = Instantiate(spawnManagerValues.parentObject, spawnManagerValues.spawnPoints[currentSpawnPointIndex], Quaternion.identity);

        int suitNumber = CardSuits.GetNames(typeof(CardSuits)).Length;

        int rankNumber = CardRanks.Length;

        for (int i = 0; i < suitNumber; i++)
        {
            for (int j = 0; j < rankNumber; j++)
            {
                cardName = "";
                cardName += "card" + ((CardSuits)i).ToString() + rankKeys[j];

                string cardSuit = CardSuits.GetNames(typeof(CardSuits))[i];

                int cardRank = CardRanks[j];

                // Creates an instance of the prefab at the current spawn point.
                GameObject currentEntity = Instantiate(entityToSpawn, spawnManagerValues.spawnPoints[currentSpawnPointIndex], Quaternion.identity);

                entityTranform = currentEntity.transform;

                parentTransform = parentEntity.transform;

                entityTranform.SetParent(parentTransform, false);


                //cardObject.AddComponent<SpriteRenderer>();
                //        cardObject.GetComponent<SpriteRenderer>().sprite = newSprite;



                // Sets the name of the instantiated entity to be the string defined in the ScriptableObject and then appends it with a unique number. 
                currentEntity.name = cardName;

                // Moves to the next spawn point index. If it goes out of range, it wraps back to the start.
                currentSpawnPointIndex = (currentSpawnPointIndex + 1) % spawnManagerValues.spawnPoints.Length;
             }
        }
    }
}

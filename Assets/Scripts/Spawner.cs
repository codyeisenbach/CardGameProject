using System.Collections;
using System.Collections.Generic;
using UnityEditor.AddressableAssets.Build.Layout;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Spawner : MonoBehaviour
{


    private Transform cardTransform;
    private Transform parentTransform;

    public GameObject cardDeck;
    public GameObject entityToSpawn;
    public SpritesData spritesData;
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
        SpawnEntities();
    }

    void SpawnEntities()
    {

        //GameObject parentEntity = Instantiate(spawnManagerValues.parentObject, spawnManagerValues.spawnPoints[currentSpawnPointIndex], Quaternion.identity);



            foreach (Sprite sprite in spritesData.sprites)
            {

                // Creates an instance of the prefab at the current spawn point.
                GameObject currentCard = Instantiate(entityToSpawn);

            cardTransform = currentCard.transform;

            parentTransform = cardDeck.transform;

            cardTransform.SetParent(parentTransform, false);

            Debug.Log($"sprite: {sprite}");

            //cardObject.AddComponent<SpriteRenderer>();
            currentCard.GetComponent<SpriteRenderer>().sprite = sprite;

            currentCard.name = sprite.name;

             }
        
    }
}

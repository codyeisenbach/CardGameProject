using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;


public class BasicReference : MonoBehaviour
{

    public AssetReference baseCard;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnThing()
    {
        baseCard.InstantiateAsync();
    }
}

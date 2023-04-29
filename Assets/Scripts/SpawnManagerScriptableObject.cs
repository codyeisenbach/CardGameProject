using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ScriptableCard", order = 1)]
public class ScriptableCard : ScriptableObject
{

    public string prefabName;

    public GameObject parentObject;

    //public int numberOfPrefabsToCreate;
    public UnityEngine.Vector3[] spawnPoints;
}
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpritesData", menuName = "ScriptableObjects/SpritesData", order = 1)]
public class SpritesData : ScriptableObject
{
    public List<Sprite> sprites;
}

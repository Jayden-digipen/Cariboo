using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Game Items", order = 1)]
public class Item : ScriptableObject
{
    public string id;
    public string description;
    public Sprite icon;
    public GameObject prefab;
}

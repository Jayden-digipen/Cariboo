using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    [Header("Gameplay")]
    public GameObject Game;
    public ItemType type;
    public ActionType action;
    public Vector2Int range = new Vector2Int(5, 4);

    [Header("UI")]
    public bool stackable = true;


    [Header("Both")]
    public string itemName;
    public Sprite image;
}


public enum ItemType
{
    Lighter,
    Notes,
    Keys,
    Medicine,
    Stamina

}

public enum ActionType
{
    Consume,
    Interact
}

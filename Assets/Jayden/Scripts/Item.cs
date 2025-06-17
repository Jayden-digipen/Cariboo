using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    [Header("Gameplay")]
   
    public ItemType type;
    public ActionType action;
   

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
    MasterKey,
    Medicine,
    Stamina,
    Concealment,
    Triangle,
    Circle,
    Square,
    Star

}

public enum ActionType
{
    Consume,
    Interact
}

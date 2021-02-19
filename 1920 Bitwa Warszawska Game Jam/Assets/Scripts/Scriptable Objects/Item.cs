using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Basic Item")]
public class Item : ScriptableObject
{
    [SerializeField] GameObject sprite;
    [SerializeField] bool storeable;
    [SerializeField] bool isQuestItem;
    [SerializeField] int itemID;


    public bool IsStoreable { get { return storeable; } }
    public bool IsQuestItem { get { return IsQuestItem; } }
    public GameObject ItemUI { get { return sprite; } }
    public int ItemID { get { return itemID; } }
}

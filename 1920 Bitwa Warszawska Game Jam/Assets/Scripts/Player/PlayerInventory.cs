using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] Item[] Inventory = new Item[7];

    public void AddItem(Item newItem, int inventorySlot)
    {
        if (Inventory[inventorySlot] == null)
        {
            Inventory[inventorySlot] = newItem;
            //Debug.Log(newItem.ItemID);
            //Debug.Log(Inventory[inventorySlot].ItemID);
        }     
    }

    public void RemoveItem(int index)
    {
        if (Inventory[index] != null)
        {
            Inventory[index] = null;
        }
    }

    public bool IsInventorySlotOccupied(int index)
    {
        return Inventory[index] == null ? false : true;
    }

    public void SaveInventory()
    {

    }
}

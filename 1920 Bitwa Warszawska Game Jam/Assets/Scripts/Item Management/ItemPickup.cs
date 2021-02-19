using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] GameUI gameUI;
    PlayerInventory playerInventory;

    int inventorySpace = 7;

    public Item itemInfo { get { return item; } }

    private void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
    }

    public void PickUp()
    {
        if (item.IsStoreable)
        {
            for(int i = 0; i < inventorySpace; i++)
            {
                if (!playerInventory.IsInventorySlotOccupied(i))
                {
                    playerInventory.AddItem(item, i);
                    gameUI.AddItemToUIGameInventory(item, i);
                    Destroy(gameObject);
                    return;
                }
            }
            Debug.Log("[ItemPickup] Inventory is full!");
            //toggle swap items window (inventory slot to swap for|don't pick up item)
        }
    }
}

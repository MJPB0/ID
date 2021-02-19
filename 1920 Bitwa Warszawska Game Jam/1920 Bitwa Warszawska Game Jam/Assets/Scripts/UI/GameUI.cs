using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] Button[] inventory = new Button[7];
    [SerializeField] GameObject[] items = new GameObject[7];
    [SerializeField] bool[] itemInInventorySlot = new bool[7];
    Player player;
    PlayerInventory playerInventory;

    [SerializeField] InsertItemWindow insertItemWindow;

    const string INVENTORY_KEY = "Inventory";

    private void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        player = FindObjectOfType<Player>();
        ToggleInventoryUI(false);

        inventory[0].onClick.AddListener(InventorySlot0);
        inventory[1].onClick.AddListener(InventorySlot1);
        inventory[2].onClick.AddListener(InventorySlot2);
        inventory[3].onClick.AddListener(InventorySlot3);
        inventory[4].onClick.AddListener(InventorySlot4);
        inventory[5].onClick.AddListener(InventorySlot5);
        inventory[6].onClick.AddListener(InventorySlot6);
    }

    private void Update()
    {
        if (Input.GetButtonDown(INVENTORY_KEY))
        {
            ToggleInventoryUI(inventory[0].gameObject.activeInHierarchy ? false : true);
        }
    }

    public void AddItemToUIGameInventory(Item item, int index)
    {
        var newItem = Instantiate(item.ItemUI, inventory[index].gameObject.transform.position, Quaternion.identity);
        items[index] = newItem;
        newItem.transform.SetParent(inventory[index].transform);
        itemInInventorySlot[index] = true;

        //Debug.Log(item.ItemID);
    }
    public void AddItemToUIGameInventory(GameObject item, int index)
    {
        items[index] = item;
        item.transform.SetParent(inventory[index].transform);
        item.transform.localPosition = new Vector3(0, 0, 0);
        itemInInventorySlot[index] = true;
    }

    public void RemoveItemFromUIGameInventory(int index)
    {
        itemInInventorySlot[index] = false;
        items[index] = null;
    }

    public void ToggleInventoryUI(bool isActive)
    {
        foreach(Button slot in inventory)
        {
            slot.gameObject.SetActive(isActive);
        }
    }

    #region Inventory Slot OnClick Functions
    private void InventorySlot0()
    {
        if (player.IsInsertingItem && itemInInventorySlot[0])
        {
            if (!insertItemWindow.ItemSlotOccupied)
            {
                insertItemWindow.InsertItem(items[0]);
                RemoveItemFromUIGameInventory(0);
                playerInventory.RemoveItem(0);
            }
        }
    }
    private void InventorySlot1()
    {
        if (player.IsInsertingItem && itemInInventorySlot[1])
        {
            if (!insertItemWindow.ItemSlotOccupied)
            {
                insertItemWindow.InsertItem(items[1]);
                RemoveItemFromUIGameInventory(1);
                playerInventory.RemoveItem(1);
            }
        }
    }
    private void InventorySlot2()
    {
        if (player.IsInsertingItem && itemInInventorySlot[2])
        {
            if (!insertItemWindow.ItemSlotOccupied)
            {
                insertItemWindow.InsertItem(items[2]);
                RemoveItemFromUIGameInventory(2);
                playerInventory.RemoveItem(2);
            }
        }
    }
    private void InventorySlot3()
    {
        if (player.IsInsertingItem && itemInInventorySlot[3])
        {
            if (!insertItemWindow.ItemSlotOccupied)
            {
                insertItemWindow.InsertItem(items[3]);
                RemoveItemFromUIGameInventory(3);
                playerInventory.RemoveItem(3);
            }
        }
    }
    private void InventorySlot4()
    {
        if (player.IsInsertingItem && itemInInventorySlot[4])
        {
            if (!insertItemWindow.ItemSlotOccupied)
            {
                insertItemWindow.InsertItem(items[4]);
                RemoveItemFromUIGameInventory(4);
                playerInventory.RemoveItem(4);
            }
        }
    }
    private void InventorySlot5()
    {
        if (player.IsInsertingItem && itemInInventorySlot[5])
        {
            if (!insertItemWindow.ItemSlotOccupied)
            {
                insertItemWindow.InsertItem(items[5]);
                RemoveItemFromUIGameInventory(5);
                playerInventory.RemoveItem(5);
            }
        }
    }
    private void InventorySlot6()
    {
        if (player.IsInsertingItem && itemInInventorySlot[6])
        {
            if (!insertItemWindow.ItemSlotOccupied)
            {
                insertItemWindow.InsertItem(items[6]);
                RemoveItemFromUIGameInventory(6);
                playerInventory.RemoveItem(6);
            }
        }
    }
    #endregion
}

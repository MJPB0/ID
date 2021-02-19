using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsertItemWindow : MonoBehaviour
{
    [SerializeField] Button cancelButton;
    [SerializeField] Button applyButton;
    [SerializeField] Transform insertItemSlot;
    [SerializeField] InteractableObject currentlyInteractingWith;

    [SerializeField] bool itemSlotOccupied = false;
    public bool ItemSlotOccupied { get { return itemSlotOccupied; } }
    public Transform InsertItemSlot { get { return insertItemSlot; } }
    public Button CancelButton { get { return cancelButton; } }
    public Button ApplyButton { get { return applyButton; } }
    public InteractableObject CurrentlyInteractingWith { get { return currentlyInteractingWith; } set { currentlyInteractingWith = value; } }

    int inventorySpace = 7;

    Player player;
    PlayerInventory playerInventory;
    GameUI gameUI;

    private void Start()
    {
        gameObject.SetActive(false);

        player = FindObjectOfType<Player>();
        playerInventory = FindObjectOfType<PlayerInventory>();
        gameUI = GetComponentInParent<GameUI>();

        cancelButton.onClick.AddListener(CancelItemInserting);
        applyButton.onClick.AddListener(ApplyItemInserting);
    }

    public void ToggleInsertItemWindow(bool isActive)
    {
        gameObject.SetActive(isActive);
    }


    public void InsertItem(GameObject item)
    {
        //Debug.Log("Inserting item...");

        item.transform.SetParent(insertItemSlot.transform);
        item.transform.localPosition = new Vector3(0, 0, 0);

        itemSlotOccupied = true;
    }

    public void ClearSlot()
    {
        //Debug.Log("Clearing item insert slot...");
        itemSlotOccupied = false;      
    }
    public void CancelItemInserting()
    {
        Debug.Log("Canceling item insert...");

        player.IsInsertingItem = false;
        player.CanMove = true;

        gameUI.ToggleInventoryUI(false);
        ToggleInsertItemWindow(false);

        if (InsertItemSlot.transform.childCount > 0)
        {
            for (int i = 0; i < inventorySpace; i++)
            {
                if (!playerInventory.IsInventorySlotOccupied(i))
                {
                    playerInventory.AddItem(InsertItemSlot.gameObject.GetComponentInChildren<ItemScript>().itemInfo, i);
                    gameUI.AddItemToUIGameInventory(InsertItemSlot.gameObject.GetComponentInChildren<ItemScript>().gameObject, i);
                    break;
                }
            }
        }

        ClearSlot();
        currentlyInteractingWith = null;
    }

    void ApplyItemInserting()
    {
        if (!ItemSlotOccupied)
        {
            //Debug.Log("No item in item insert slot!");
        }
        else
        {
            ItemCheck();
        }
    }

    public void ItemCheck()
    {
        if (InsertItemSlot.GetComponentInChildren<ItemScript>().itemInfo.ItemID == currentlyInteractingWith.ItemID)
        {
            Debug.Log("Correct item");

            currentlyInteractingWith.IsOpenable = true;
            ToggleInsertItemWindow(false);

            PlayerController.PlayerWalkEnablerHandler();

            ClearSlot();
            Destroy(InsertItemSlot.GetComponentInChildren<ItemScript>().gameObject);
            currentlyInteractingWith = null;
        }
        else
        {
            Debug.Log("Incorrect item, canceling item insert. Expected ID: " + currentlyInteractingWith.ItemID + ", inserted item's ID: " +
                InsertItemSlot.GetComponentInChildren<ItemScript>().itemInfo.ItemID);
            CancelItemInserting();
            currentlyInteractingWith = null;
        }
    }

}

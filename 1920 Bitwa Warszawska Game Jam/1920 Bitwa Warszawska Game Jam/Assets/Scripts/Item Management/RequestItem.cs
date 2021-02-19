using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestItem : MonoBehaviour
{
    [SerializeField] InsertItemWindow insertItemWindow;
    [SerializeField] PlayerInventory playerInventory;
    GameUI gameUI;
    Player player;

    private void Start()
    {
        gameUI = FindObjectOfType<GameUI>();
        player = FindObjectOfType<Player>();
    }

    public void RequestItemInsert(InteractableObject requestingObject)
    {
        Debug.Log("Requesting item insert...");
        player.IsInsertingItem = true;
        player.CanMove = false;
        gameUI.ToggleInventoryUI(true);
        insertItemWindow.ToggleInsertItemWindow(true);
        insertItemWindow.CurrentlyInteractingWith = requestingObject;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour
{
    [SerializeField] InteractableObject interactableObject;

    [SerializeField] GameObject itemHeGives;
    [SerializeField] bool gaveItem = false;

    [SerializeField] bool isTalking;

    Animator anim;
    RequestItem requestItem;

    [SerializeField] PlayerInventory playerInventory;
    [SerializeField] GameUI gameUI;

    private int inventorySpace = 7;

    private void Start()
    {
        TryGetComponent<Animator>(out anim);

        //Debug.Log(gameObject.name + " ; " + interactableObject.ItemID);

        if (!interactableObject.IsOpenable)
        {
            requestItem = GetComponent<RequestItem>();
        }
    }

    public void InteractWithAlly(Transform playerTransform)
    {
        Vector3 targetDirection = new Vector3(playerTransform.position.x - transform.position.x, 0, playerTransform.position.z - transform.position.z);
        var newRotation = Vector3.RotateTowards(gameObject.transform.position, targetDirection , 180f, 0f);
        transform.rotation = Quaternion.LookRotation(newRotation);

        if (isTalking)
        {
            Debug.Log(gameObject.name + " is Talking...");
        }else if (interactableObject.IsOpenable && !gaveItem)
        {
            GiveItem();
        }else if (!interactableObject.IsOpenable && !gaveItem)
        {
            requestItem.RequestItemInsert(interactableObject);
        }
    } 

    void GiveItem()
    {
        for (int i = 0; i < inventorySpace; i++)
        {
            if (!playerInventory.IsInventorySlotOccupied(i))
            {
                playerInventory.AddItem(itemHeGives.GetComponentInChildren<ItemScript>().itemInfo, i);
                gameUI.AddItemToUIGameInventory(itemHeGives.GetComponent<ItemScript>().itemInfo, i);
                gaveItem = true;
                break;
            }
        }
    }
}

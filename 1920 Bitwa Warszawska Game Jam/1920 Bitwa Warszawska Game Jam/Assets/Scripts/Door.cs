using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] bool hasOpened = false;
    [SerializeField] InteractableObject interactableObject;
    [SerializeField] bool openableIndicator;

    Animator anim;
    RequestItem requestItem;

    private void Start()
    {
        interactableObject.IsOpenable = openableIndicator;
        TryGetComponent<Animator>(out anim);

        //Debug.Log(gameObject.name + " ; " + interactableObject.ItemID);

        if (!interactableObject.IsOpenable)
        {
            requestItem = GetComponent<RequestItem>();
        }
    }

    public void TryToOpenDoors()
    {
        if (interactableObject.IsOpenable && !hasOpened)
        {
            OpenDoors();
        }else if (!interactableObject.IsOpenable && !hasOpened)
        {
            requestItem.RequestItemInsert(interactableObject);
        }
    }

    void OpenDoors()
    {
        if(anim != null)
            anim.SetTrigger("doorOpened");

        hasOpened = true;
    }    
}

using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using System;

public class PlayerController : MonoBehaviour
{
    public static Action PlayerWalkEnabler;

    [SerializeField] Camera cam;
    [SerializeField] NavMeshAgent agent;
    Player player;

    [Space]

    [SerializeField] GameObject currentTarget;
    [SerializeField] GameObject defaultTarget;
    [SerializeField] float pickupRange = 1f;
    //[SerializeField] float distanceBetweenPlayerAndTarget;

    [Space]

    [SerializeField] float doorOpeningWaitTime = 2f;
    [SerializeField] float keyPickUpWaitTime = 1f;

    const string GROUND_TAG_KEY = "Ground";
    const string DOOR_TAG_KEY = "Door";
    const string ITEM_TAG_KEY = "Item";
    const string ALLY_TAG_KEY = "Ally";

    private void Start()
    {
        player = GetComponent<Player>();

        PlayerWalkEnabler += PlayerNoLongerInsertingItem;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && player.CanMove)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.CompareTag(GROUND_TAG_KEY))
                {
                    agent.SetDestination(hit.point);
                    currentTarget = hit.collider.gameObject;
                }else if (hit.collider.gameObject.CompareTag(DOOR_TAG_KEY))
                {
                    agent.SetDestination(hit.point);
                    currentTarget = hit.collider.gameObject;
                }else if (hit.collider.gameObject.CompareTag(ITEM_TAG_KEY))
                {
                    agent.SetDestination(hit.point);
                    currentTarget = hit.collider.gameObject;
                }else if (hit.collider.gameObject.CompareTag(ALLY_TAG_KEY))
                {
                    agent.SetDestination(hit.point);
                    currentTarget = hit.collider.gameObject;
                }

            }
        }

        if(Vector3.Distance(gameObject.transform.position, currentTarget.transform.position) <= pickupRange && !currentTarget.CompareTag(GROUND_TAG_KEY))
        {
            agent.SetDestination(gameObject.transform.position);
            //Debug.Log("Interacting with " + currentTarget.gameObject.name);
            switch (currentTarget.tag)
            {
                case ITEM_TAG_KEY:
                    currentTarget.GetComponent<ItemPickup>().PickUp();
                    currentTarget = defaultTarget;
                    WaitToMove(keyPickUpWaitTime);
                    break;
                case DOOR_TAG_KEY:
                    currentTarget.GetComponentInParent<Door>().TryToOpenDoors();
                    currentTarget = defaultTarget;
                    break;
                case ALLY_TAG_KEY:
                    currentTarget.GetComponentInParent<Ally>().InteractWithAlly(player.gameObject.transform);
                    currentTarget = defaultTarget;
                    break;
            }
        }

        //distanceBetweenPlayerAndTarget = Vector3.Distance(gameObject.transform.position, currentTarget.transform.position);
    }

    IEnumerator WaitToMove(float waitTime)
    {
        player.CanMove = false;

        yield return new WaitForSeconds(waitTime);

        if (!player.IsInsertingItem)
            player.CanMove = true;
    }

    void PlayerNoLongerInsertingItem()
    {
        player.IsInsertingItem = false;
        player.CanMove = true;
    }

    public static void PlayerWalkEnablerHandler()
    {
        PlayerWalkEnabler?.Invoke();
    }
}

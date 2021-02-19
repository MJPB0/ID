using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int currentRoom = 0;
    [SerializeField] bool canMove = true;
    [SerializeField] bool isInsertingItem = false;
    public int CurrentRoom { get { return currentRoom; } set { currentRoom = value; } }
    public bool CanMove { get { return canMove; } set { canMove = value; } }
    public bool IsInsertingItem { get { return isInsertingItem; } set { isInsertingItem = value; } }

}

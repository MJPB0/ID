using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Interactable Object")]
public class InteractableObject : ScriptableObject
{
    [SerializeField] int itemID;
    [SerializeField] bool isOpenable;
    public int ItemID { get { return itemID; } }
    public bool IsOpenable { get { return isOpenable; } set { isOpenable = value; } }
}

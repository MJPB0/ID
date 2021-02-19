using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    [SerializeField] Item item;
    public Item itemInfo { get { return item; } }
}

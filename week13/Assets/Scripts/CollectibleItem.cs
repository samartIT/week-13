using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] private string itemName;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Item collected = " + itenName);
        //Destroy(gameObject);
        Managers.Inventory.AddItem(itemName);
    }
}

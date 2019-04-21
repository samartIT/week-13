using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] private string itemName;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("item collected = " + itemName);
        Manager.Inventory.AddItem(itemName);
        //Destroy (this.gameObject);
    }
}

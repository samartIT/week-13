using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] private string itemName;

    void OnTriggerEnter()
    {
        Debug.Log("item collected = " + itemName);
        Destroy (this.gameObject);
    }
}

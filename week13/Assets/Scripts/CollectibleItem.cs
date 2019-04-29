using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] private string itemName;
    // Start is called before the first frame update
    void OnTriggerEnter()
    {
        Debug.Log("item collected = " + itemName);
        Destroy (this.gameObject);
    }
}
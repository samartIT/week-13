using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggered : MonoBehaviour
{
    [SerializeField] private GameObject[] targets;
    void OnTriggerEnter(Collider other)
    {
        foreach (GameObject target in targets)
        {
            target.SendMessage("Activate");
        }
    }

    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        foreach (GameObject target in targets)
        {
            target.SendMessage("Deactivate");
        }
    }
}

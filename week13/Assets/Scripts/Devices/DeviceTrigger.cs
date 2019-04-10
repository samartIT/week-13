﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] targets;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        foreach (GameObject target in targets) {
            target.SendMessage("Activate");
        }
    }

    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        foreach (GameObject target in targets) {
            target.SendMessage("Deactivate");
        }
    }
}

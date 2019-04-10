﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenDev : MonoBehaviour
{
    [SerializeField] private Vector3 dPos;
    private bool _open;
    
    public void Operate()
    {
        if (_open)
        {
            Vector3 pos = transform.position - dPos;
            transform.position = pos;
        } else
        {
            Vector3 pos = transform.position + dPos;
            transform.position = pos;
        }
        _open = !_open;
    }
}

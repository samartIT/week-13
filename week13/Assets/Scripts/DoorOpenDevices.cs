using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenDevices : MonoBehaviour {
    [SerializeField] private Vector3 dPos;
    private bool _open;
    // Start is called before the first frame update
    public void Operate()
    {
        if (_open)
        {
            Vector3 pos = transform.position - dPos;
            transform.position = pos;
        }
        else
        {
            Vector3 pos = transform.position + dPos;
            transform.position = pos;
        }
        _open = !_open;
    }
    public void Active()
    {
        Debug.Log("Active");
        if (!_open)
        {
            Vector3 pos = transform.position + dPos;
            transform.position = pos;
            _open = true;
        }
    }
    public void Deactive()
    {
        Debug.Log("Deactive");
        if (_open)
        {
            Vector3 pos = transform.position - dPos;
            transform.position = pos;
            _open = false;
        }
    }
}

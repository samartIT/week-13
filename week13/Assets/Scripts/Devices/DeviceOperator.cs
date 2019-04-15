using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceOperator : MonoBehaviour
{
    public float raduis = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {

            Collider[] hitColiders = Physics.OverlapSphere(transform.position, raduis);
            foreach (Collider hitColider in hitColiders)
            {
                Vector3 direction = hitColider.transform.position - transform.position;
                if(Vector3.Dot(transform.forward, direction) > 0.5f)
                {
                    hitColider.SendMessage("Operate", SendMessageOptions.DontRequireReceiver);
                }
                Debug.Log(Vector3.Dot(transform.forward, direction));
            }
        }
    }
}

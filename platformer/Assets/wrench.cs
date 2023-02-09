using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrench : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

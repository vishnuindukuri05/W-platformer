using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3 (0,0.01f,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

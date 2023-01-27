using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    float fuel;
    void Start()
    {
        fuel = 10;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space) && fuel >0){
            fuel -= Time.fixedDeltaTime;
            gameObject.GetComponent<Rigidbody>().AddForce(5 * transform.forward, ForceMode.Impulse);
        }
    }
}

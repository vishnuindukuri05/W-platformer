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
        if (fuel >0){
            if(Input.GetKey(KeyCode.Space)){
                fuel -= Time.fixedDeltaTime;
                gameObject.GetComponent<Rigidbody>().AddForce(2 * transform.forward, ForceMode.Impulse);
            }
            if (Input.GetKey(KeyCode.W)){
                fuel -= Time.fixedDeltaTime;
                gameObject.GetComponent<Rigidbody>().AddForce(2 * -transform.up, ForceMode.Impulse);
            }
            if (Input.GetKey(KeyCode.A)){
                fuel -= Time.fixedDeltaTime/2;
                gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(0,-3,0));
            }
            if (Input.GetKey(KeyCode.D)){
                fuel -= Time.fixedDeltaTime/2;
                gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(0,3,0));
            }
        }
    }
}

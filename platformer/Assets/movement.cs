using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    float fuel;
    ParticleSystem left;
    ParticleSystem right;
    ParticleSystem up;
    ParticleSystem foraward;
    void Start()
    {
        fuel = 10;
        left = gameObject.transform.GetChild(2).gameObject.GetComponent<ParticleSystem>();
        right = gameObject.transform.GetChild(3).gameObject.GetComponent<ParticleSystem>();
        up = gameObject.transform.GetChild(4).gameObject.GetComponent<ParticleSystem>();
        foraward = gameObject.transform.GetChild(5).gameObject.GetComponent<ParticleSystem>();
        Debug.Log(left.gameObject.name);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fuel >0){
            if(Input.GetKey(KeyCode.Space)){
                fuel -= Time.fixedDeltaTime;
                gameObject.GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.Impulse);
                up.Play();
            }
            if (Input.GetKey(KeyCode.W)){
                fuel -= Time.fixedDeltaTime;
                gameObject.GetComponent<Rigidbody>().AddForce(-transform.up, ForceMode.Impulse);
                foraward.Play();
            }
            if (Input.GetKey(KeyCode.A)){
                fuel -= Time.fixedDeltaTime/2;
                gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(0,-2,0));
                right.Play();
            }
            if (Input.GetKey(KeyCode.D)){
                fuel -= Time.fixedDeltaTime/2;
                gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(0,2,0));
                left.Play();
            }

        }
    }
}

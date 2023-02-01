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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            if(Input.GetKey(KeyCode.Space) && fuel >0){
                fuel -= Time.fixedDeltaTime;
                gameObject.GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.Impulse);
                foraward.Play();
            }
            else {
                foraward.Stop();
            }
            if (Input.GetKey(KeyCode.W) && fuel >0 ){
                fuel -= Time.fixedDeltaTime;
                gameObject.GetComponent<Rigidbody>().AddForce(-transform.up, ForceMode.Impulse);
                up.Play();
            }
            else {
                up.Stop();
            }
            if (Input.GetKey(KeyCode.A) && fuel >0){
                fuel -= Time.fixedDeltaTime/2;
                gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(0,-2,0));
                right.Play();
            }
            else {
                right.Stop();
            }
            if (Input.GetKey(KeyCode.D) && fuel >0){
                fuel -= Time.fixedDeltaTime/2;
                gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(0,2,0));
                left.Play();
            }
            else {
                left.Stop();
            }
    }
}

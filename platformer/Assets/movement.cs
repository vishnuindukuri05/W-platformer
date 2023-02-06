using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    float fuel;
    ParticleSystem left;
    ParticleSystem right;
    ParticleSystem up;
    ParticleSystem foraward;
    [SerializeField] Slider fuelbar;
    void Start()
    {
        fuel = 10;
        left = gameObject.transform.GetChild(2).gameObject.GetComponent<ParticleSystem>();
        right = gameObject.transform.GetChild(3).gameObject.GetComponent<ParticleSystem>();
        up = gameObject.transform.GetChild(4).gameObject.GetComponent<ParticleSystem>();
        foraward = gameObject.transform.GetChild(5).gameObject.GetComponent<ParticleSystem>();
        Physics.gravity = new Vector3(0, -0.5f, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            if(Input.GetKey(KeyCode.Space) && fuel >0){
                fuel -= Time.fixedDeltaTime;
                gameObject.GetComponent<Rigidbody>().AddForce(transform.forward/5, ForceMode.Impulse);
                foraward.Play();
            }
            else {
                foraward.Stop();
            }
            if (Input.GetKey(KeyCode.W) && fuel >0 ){
                fuel -= Time.fixedDeltaTime;
                gameObject.GetComponent<Rigidbody>().AddForce(-transform.up/5, ForceMode.Impulse);
                up.Play();
            }
            else {
                up.Stop();
            }
            if (Input.GetKey(KeyCode.A) && fuel >0){
                fuel -= Time.fixedDeltaTime/2;
                gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(0,-1,0));
                right.Play();
            }
            else {
                right.Stop();
            }
            if (Input.GetKey(KeyCode.D) && fuel >0){
                fuel -= Time.fixedDeltaTime/2;
                gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(0,1,0));
                left.Play();
            }
            else {
                left.Stop();
            }
            fuelbar.value = fuel;
    }
    private void OnGUI() {
        GUI.Label(new Rect(175, 25, 500, 100), "Fuel left");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name.ToLower().Contains("gas")){
            fuel = 10;
            Destroy(other.gameObject);
        }
    }
}

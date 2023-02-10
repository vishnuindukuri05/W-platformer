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
    ParticleSystem super;
    [SerializeField] Slider fuelbar;
    float boosttime;
    bool boosting;
    int eff;
    float deadtimer;
    bool dead;
    Quaternion initial;
    List<Vector3> checkpoints = new List<Vector3>();
    void Start()
    {
        fuel = 10;
        left = gameObject.transform.GetChild(2).gameObject.GetComponent<ParticleSystem>();
        right = gameObject.transform.GetChild(3).gameObject.GetComponent<ParticleSystem>();
        up = gameObject.transform.GetChild(4).gameObject.GetComponent<ParticleSystem>();
        foraward = gameObject.transform.GetChild(5).gameObject.GetComponent<ParticleSystem>();
        super = gameObject.transform.GetChild(6).gameObject.GetComponent<ParticleSystem>();
        super.Stop();
        Physics.gravity = new Vector3(0, -0.5f, 0);
        this.gameObject.GetComponent<AudioSource>().Play(0);
        boosttime = 2;
        boosting = false;
        eff = 1;
        deadtimer = 3;
        dead = false;
        checkpoints.Add(gameObject.transform.position);
        initial = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            if(Input.GetKey(KeyCode.Space) && fuel >0){
                fuel -= Time.fixedDeltaTime/eff;
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
            if (((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))) && fuel > 0){
                if (!this.gameObject.GetComponent<AudioSource>().isPlaying){
                    this.gameObject.GetComponent<AudioSource>().Play();
                }
            }
            else {
                this.gameObject.GetComponent<AudioSource>().Pause();
            }
            if (Input.GetKey(KeyCode.LeftShift) && fuel >=2.5 && !boosting){
                fuel -= 2.5f;
                boosting = true;
            }
            if (boosting){
                boosttime -= Time.fixedDeltaTime;
                gameObject.GetComponent<Rigidbody>().AddForce(-transform.up, ForceMode.Impulse);
                super.Play();
            }
            if (boosttime <= 0){
                boosting = false;
                boosttime = 2f;
            }
            fuelbar.value = fuel;
            if (fuel <=0){
                dead = true;
            }
            if (dead){
                deadtimer -= Time.fixedDeltaTime;
            }
            if (deadtimer <= 0){
                gameObject.transform.position = checkpoints[checkpoints.Count-1];
                deadtimer = 3;
                dead = false;
                fuel = 10;
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
                gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0,0);
                gameObject.transform.rotation = initial;
            }
    }
    private void OnGUI() {
        GUI.Label(new Rect(175, 25, 500, 100), "Fuel left");
        if (dead){
            GUI.Label(new Rect(500, 100, 500, 100), "Respawn in: "+deadtimer);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name.ToLower().Contains("gas")){
            fuel = 10;
            gameObject.transform.GetChild(7).gameObject.GetComponent<AudioSource>().Play(0);
            Destroy(other.gameObject);
            checkpoints.Add(other.gameObject.transform.position);
        }
        if (other.name.ToLower().Contains("wrench")){
            eff *= 2;
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.name.ToLower().Contains("raj") || other.gameObject.name.ToLower().Contains("kim")){
            fuel -= 2;
            other.gameObject.GetComponent<AudioSource>().Play();
        }
    }
}

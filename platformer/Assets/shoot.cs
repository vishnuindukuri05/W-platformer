using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject laser;
    GameObject laser1;
    float timer;
    void Start()
    {
        timer = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
        if (timer <= 0){
            laser1 = Instantiate(laser, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+1.606f, gameObject.transform.position.z), Quaternion.Euler(90,0,0));
            laser1.GetComponent<Rigidbody>().velocity = laser1.transform.up*3;
            timer = 1;
        }
    }
}

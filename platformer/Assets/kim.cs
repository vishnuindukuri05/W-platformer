using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kim : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int distance;
    float time;
    void Start()
    {
        time = distance;
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(2,0,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (time <= 0){
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3 (-gameObject.GetComponent<Rigidbody>().velocity.x,0,0);
            time = distance;
        }
        time -= Time.fixedDeltaTime;
    }
}

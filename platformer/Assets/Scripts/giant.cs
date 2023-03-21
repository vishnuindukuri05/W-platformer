using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giant : MonoBehaviour
{
    [SerializeField] GameObject pla;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((gameObject.transform.position - pla.transform.position).magnitude < 30){
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(Vector3.Normalize(pla.transform.position - gameObject.transform.position).x*3, 0, Vector3.Normalize(pla.transform.position - gameObject.transform.position).z*3);
        }
        else {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }
    }
}

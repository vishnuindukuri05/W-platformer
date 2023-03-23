using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giant : MonoBehaviour
{
    [SerializeField] GameObject pla;
    [SerializeField] RuntimeAnimatorController run;
    [SerializeField] RuntimeAnimatorController idle;
    [SerializeField] RuntimeAnimatorController stomp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((gameObject.transform.position - pla.transform.position).magnitude < 30){
            gameObject.transform.LookAt(pla.transform);
            if ((gameObject.transform.position - pla.transform.position).magnitude > 5){
                gameObject.GetComponent<Animator>().runtimeAnimatorController = run;
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(Vector3.Normalize(pla.transform.position - gameObject.transform.position).x*2, gameObject.GetComponent<Rigidbody>().velocity.y, Vector3.Normalize(pla.transform.position - gameObject.transform.position).z*2);
            }
            else {
                gameObject.GetComponent<Animator>().runtimeAnimatorController = stomp;
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(Vector3.Normalize(pla.transform.position - gameObject.transform.position).x*0.1f, gameObject.GetComponent<Rigidbody>().velocity.y, Vector3.Normalize(pla.transform.position - gameObject.transform.position).z*0.1f);
            }
        }
        else {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,gameObject.GetComponent<Rigidbody>().velocity.y,0);
            gameObject.GetComponent<Animator>().runtimeAnimatorController = idle;

        }
    }
}

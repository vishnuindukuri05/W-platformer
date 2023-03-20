using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{

 
 void Start() {

 }

 void Update(){
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical"); 
    float speed = 5.0f;
    transform.position = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
 }
}

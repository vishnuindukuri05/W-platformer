using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menustuff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI() {
        GUI.Label(new Rect(500, 100, 500, 100), "Fastest time: "+PlayerPrefs.GetFloat("fastest"));
    }
}

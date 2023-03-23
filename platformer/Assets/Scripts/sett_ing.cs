using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;

public class sett_ing : MonoBehaviour
{

    public Slider slider;

    private int volume;
    

    // Start is called before the first frame update
    // void Start()
    // {
    //     volume = GameObject.Find("Volume Slider").GetComponent<Slider>().value;
    // }

    public void OnValueChanged(float newValue)
    {
        Debug.Log(slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        // volume = GameObject.Find("Volume Slider").GetComponent<Slider>().value;
        // Debug.Log(volume);
    }


}
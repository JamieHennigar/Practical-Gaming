using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {
    public Light light;
    // Use this for initialization
    void Start () {
        light.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        flashLight();
    }
    private void flashLight()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            light.enabled = !light.enabled;
        }


    }
}

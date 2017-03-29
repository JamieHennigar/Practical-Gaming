using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashLight1 : MonoBehaviour {
    public Light flashLightObject;
    public bool lightOn = false;
    public float lightDrain = 0.1f;
    public float batteriesLife = 0.0f;
    public float maxBatteryLife = 2.0f;
    public float timer;
    // Use this for initialization
    void Start () {
        batteriesLife = maxBatteryLife;
        flashLightObject = GameObject.FindGameObjectWithTag("Light").GetComponent<Light>();
        timer = Time.deltaTime;
        lightOn = false;
        
}
	
	// Update is called once per frame
	void Update () {
		if(lightOn && batteriesLife >=0)
        {
            batteriesLife -= timer = lightDrain;
        }

        flashLightObject.intensity = batteriesLife;

        if(batteriesLife<=0)
        {
            batteriesLife = 0;
            lightOn = false;
        }


        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            toggleFlashLight();

            if(!lightOn)
            {
                lightOn = false;
                //flashLightObject.enabled = false;
                Debug.Log("off");
            }

            else if(lightOn && batteriesLife >=0)
            {
                lightOn = true;
               // flashLightObject.enabled = true;
                Debug.Log("on");
            }

        }

	}

    private void toggleFlashLight()
    {
        if(lightOn)
        {
            flashLightObject.enabled = false;
            lightOn = false;
            Debug.Log("notEnabled");
        }
        else
        {
            flashLightObject.enabled = true;
            lightOn = true;
            Debug.Log("Enabled");
        }

    }

    internal void addBatteryLife()
    {
        batteriesLife = maxBatteryLife;
    }

    internal void NewBattery()
    {
        batteriesLife = maxBatteryLife;
    }
}

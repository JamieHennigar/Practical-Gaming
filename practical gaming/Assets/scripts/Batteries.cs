using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batteries : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pickUpBattery();

    }

    private void pickUpBattery()
    {
        Ray mousePointer = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitBattery;

        if(Physics.Raycast(mousePointer, out hitBattery))
        {
            flashLight1 battery = hitBattery.collider.gameObject.GetComponent<flashLight1>();

            //if (Vector3.Distance(transform.position, battery.transform.position) < 5)
            //{
            //    battery.addBatteryLife();
                
            //}
        }
    }
}

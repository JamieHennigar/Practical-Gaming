using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockedDoorsManager : MonoBehaviour {

    public Transform Player;
    int numberOfKeys = 10;
    bool[] keysFound;
    // Use this for initialization
    void Start () {
        keysFound = new bool[numberOfKeys]; // all false as default
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
            openLock();
    }

    private void openLock()
    {
        Ray mousePointer = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hitDoor;

        if (Physics.Raycast(mousePointer, out hitDoor))
        {
            Debug.Log(hitDoor.transform.name);
            lockedDoors doorToUnlock = hitDoor.collider.gameObject.GetComponent<lockedDoors>();
            PickUpObject keyToUse = hitDoor.collider.gameObject.GetComponent<PickUpObject>();
           // Debug.Log("0");
           // Debug.Log(doorToUnlock);
            if (doorToUnlock)
            {
                Debug.Log("1. distance");
                if (Vector3.Distance(transform.position, doorToUnlock.transform.position) < 5)
                {
                    //Debug.Log("2. lock number");
                    if (keysFound[doorToUnlock.doornumber] )
                    {
                        Debug.Log("2. have the key = " + GameObject.FindGameObjectWithTag("Player").GetComponent<PickUpManager>().gotKey);
                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PickUpManager>().gotKey)
                        {
                            Debug.Log("3. open the door");
                            doorToUnlock.open();

                            
                        }

                    }

                }
            }
        }
    }

    internal void InformLockManagerFoundKey(int keyNumber)
    {
        keysFound[keyNumber] = true;
    }
}

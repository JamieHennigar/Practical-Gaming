using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockedDoorsManager : MonoBehaviour {

    public Transform Player;
    // Use this for initialization
    void Start () {
		
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

        if (Physics.Raycast(mousePointer, out hitDoor, 100))
        {
            Debug.Log(hitDoor.collider.gameObject);
            lockedDoors doorToUnlock = hitDoor.collider.gameObject.GetComponent<lockedDoors>();
            Debug.Log("0");
            Debug.Log(doorToUnlock);
            if (doorToUnlock)
            {
                Debug.Log("1");
                if (Vector3.Distance(transform.position, doorToUnlock.transform.position) < 5)
                {
                    Debug.Log("2");
                    if (doorToUnlock.thisDoor == lockedDoors.doors.lock1)
                    {
                        Debug.Log("3");
                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PickUpManager>().gotKey1)
                        {
                            Debug.Log("4");
                            GameObject.FindGameObjectWithTag("LockedDoor1").GetComponent<Animation>().Play("Door_Open");
                        }

                    }

                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorsWithNoLock : MonoBehaviour {

    public  GameObject door;
      Animator doorAnimator;
     bool doorOpen = false;
   
    // Use this for initialization
    void Start () {
        doorAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Mouse0))
        {
            openDoors();

        }
    }







    private void openDoors()
    {
        Ray mousePointer = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(mousePointer, out hit))
       {
            if (Vector3.Distance(transform.position, door.transform.position) < 5)
            {
                if (hit.collider.gameObject == this.gameObject)
              // if(this.gameObject)
                {
                    print("Open Sesame");
                    doorAnimator.SetBool("open", true);


                    doorOpen = true;
               }
            }
        }
        /*else if (Vector3.Distance(transform.position, door.transform.position) < 5 && (doorOpen = true))
        {
            doorAnimator.Play("Door_Close");
            doorOpen = false;
        }
        else
            doorOpen = false;*/
    }

    /* private void closeDoors()
     {
         if (Vector3.Distance(transform.position, door.transform.position) < 5  &&(doorOpen = true ))
         {
             doorAnimator.Play("Door_Close");
             doorOpen = false;
         }
     }*/


}

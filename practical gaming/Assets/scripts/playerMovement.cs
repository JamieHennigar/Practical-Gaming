using UnityEngine;
using System.Collections;
using System;

public class playerMovement : MonoBehaviour {
    public float moveSpeed = 5.0f;
    public float lookSpeed = 5.0f;
    public float sprintSpeed = 10.0f;
    public float gravity = 15.0f;
    public float jump = 0.1f;
    

    Vector3 velocity;
    public float rotationX;
    public float rotationY;
    private bool playerJumping = true;

    //public bool on = false;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update ()
    {

        playerWalk();
        playerLook();
        playerSprint();
        playerJump();
        playerCrouch();

        if (playerJumping) velocity += gravity * Vector3.down * Time.deltaTime;
        else
            velocity = new Vector3(0, 0, 0);
        transform.position += velocity * Time.deltaTime;
	}



    private void playerWalk()
    {
      // velocity = new Vector3(0, velocity.y, 0);

        if( Input.GetKey(KeyCode.W))
        {
           // velocity += transform.forward * moveSpeed;
          //  Camera.main.transform.Translate(new Vector3(0, 0, moveSpeed * Time.deltaTime));
           transform.position  += transform.forward * moveSpeed * Time.deltaTime;
             
        }

        if (Input.GetKey(KeyCode.S))
        {
            //velocity += -transform.forward * moveSpeed;
            transform.position -= transform.forward * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
           // velocity -= transform.right * moveSpeed;
            transform.position -= transform.right * moveSpeed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.D))
        {
           // velocity += transform.right * moveSpeed;
          transform.position += transform.right * moveSpeed * Time.deltaTime;

        }
    }

    private void playerLook()
    {
        rotationX = Input.GetAxis("Mouse X");
        rotationY = Input.GetAxis("Mouse Y");

       
        transform.Rotate(Vector3.up, rotationX);
        Camera.main.transform.Rotate(Vector3.right, -rotationY);
        //transform.Rotate(Vector3.right, -rotationY);


    }

    private void playerSprint()
    {
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
			transform.position  += transform.forward * sprintSpeed * Time.deltaTime;
            //velocity += transform.forward * sprintSpeed;
        }
    }

    private void playerJump()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            velocity += jump * Vector3.up;
            playerJumping = true;
        }

      //  transform.position -= gravity * Time.deltaTime;
    }

    private void playerCrouch()
    {
        if(Input.GetKey(KeyCode.LeftControl))
        {

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Floor")
        {
            if (playerJumping)
            {
                playerJumping = false;

            }
            

        }
    }

   /* private void theNoLockDoors()
    {
        Ray mousePointer = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(mousePointer, out hit))
        {
            if (hit.collider.gameObject == this.gameObject)
            {
                doorsWithNoLock.openDoors();
            }
        }
    }*/





}

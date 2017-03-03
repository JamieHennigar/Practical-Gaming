using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {
    public float moveSpeed = 5.0f;
    public float lookSpeed = 5.0f;

    public float rotationX;
    public float rotationY;
    
    //public bool on = false;
     
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update ()
    {

        playerWalk();
        playerLook();
        
	
	}

    private void playerWalk()
    {
        if( Input.GetKey(KeyCode.W))
        {
          //  Camera.main.transform.Translate(new Vector3(0, 0, moveSpeed * Time.deltaTime));
         transform.position  += transform.forward * moveSpeed * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * moveSpeed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.D))
        {
          transform.position += transform.right * moveSpeed * Time.deltaTime;

        }
    }

    private void playerLook()
    {
        rotationX = Input.GetAxis("Mouse X");
        rotationY = Input.GetAxis("Mouse Y");

       
        transform.Rotate(Vector3.up, rotationX);
        Camera.main.transform.Rotate(Vector3.right, -rotationY);


    }

   
   


}

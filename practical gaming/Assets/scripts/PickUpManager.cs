using UnityEngine;
using System.Collections;
using System;

public class PickUpManager : MonoBehaviour {
    public Transform Player;
    public Transform flashlight;
    public GameObject Key;
    lockedDoorsManager doors;
    flashLight1 theFlashLight;
    public Ray mousePointer = Camera.main.ScreenPointToRay(Input.mousePosition);

    // public GameObject Key1, Key2, Key3, Key4, Key5, key6, key7, key8, key9, finalKey;
    /*public bool gotKey1 = false, gotKey2 = false, gotKey3 =false, gotKey4 = false, gotKey5 = false, 
                 gotKey6 = false, gotKey7 = false, gotKey8 = false, gotKey9= false, gotFinalKey = false;*/
    public bool gotKey = false;



    // Use this for initialization
    void Start () {
        doors = FindObjectOfType<lockedDoorsManager>();
        theFlashLight = FindObjectOfType<flashLight1>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetMouseButtonDown(0))
            checkForObject();

	}

    internal void AddHealth(int v)
    {
        print("Helath incrreases by " + v.ToString());
    }

    internal void KeyCollected()
    {
        print("Key COllected ");
    }


    void checkForObject()
    {
       print("Mouse Pressed");
       

        RaycastHit hitObject;


        if (Physics.Raycast( mousePointer, out hitObject))
        {
            Debug.DrawLine(Camera.main.transform.position, hitObject.point, Color.red);
            PickUpObject objectToPick = hitObject.collider.gameObject.GetComponent<PickUpObject>();
            Debug.Log(objectToPick);
            if (objectToPick)
            {

                if (Vector3.Distance(transform.position, objectToPick.transform.position) < 5)
                {

                    if (objectToPick.thisType == PickUpObject.PickUP.Health) { print("Health"); }

                    if (objectToPick.thisType == PickUpObject.PickUP.Key)
                    {
                        print("Key");
                        GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<enemySpawn>().SendMessage("SpawnEnemy");
                        // SendMessage("SpawnEnemy");
                        doors.InformLockManagerFoundKey(objectToPick.KeyNumber);
                        Destroy(objectToPick.gameObject);
                        gotKey = true;

                    }

                    if (objectToPick.thisType == PickUpObject.PickUP.FlashLight)
                    {
                        print("Flashlight");
                        //flashlight.transform.parent = Player.transform;
                        Destroy(flashlight);

                    }

                    if (objectToPick.thisType == PickUpObject.PickUP.battery)
                    {
                        print("battery");
                        theFlashLight .NewBattery();

                        Destroy(objectToPick.gameObject);

                    }
                }
            }

        }
    }
    /*    public void whatMouseClicked()
    {
        print("Mouse Pressed");
        Ray mousePointer = Camera.main.ScreenPointToRay(Input.mousePosition);
    }*/

        //if (Vector3.Distance(transform.position, Player.position) < 5)
        //{
        //    CollectableObject.GetComponent<PickUpManager>().KeyCollected();
        //    Destroy(this.gameObject);
        //}



    }

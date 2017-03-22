using UnityEngine;
using System.Collections;
using System;

public class PickUpManager : MonoBehaviour {
    public Transform Player;
    public Transform flashlight;
    public GameObject Key1, Key2, Key3, Key4, Key5, key6, key7, key8, key9, finalKey;
    public bool gotKey1 = false, gotKey2 = false, gotKey3 =false, gotKey4 = false, gotKey5 = false, 
                 gotKey6 = false, gotKey7 = false, gotKey8 = false, gotKey9= false, gotFinalKey = false;


    // Use this for initialization
    void Start () {
	
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
        Ray mousePointer = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitObject;


        if (Physics.Raycast(mousePointer, out hitObject))
        {
            Debug.DrawLine(Camera.main.transform.position, hitObject.point, Color.red);
            PickUpObject objectToPick = hitObject.collider.gameObject.GetComponent<PickUpObject>();
            Debug.Log(objectToPick);
            if (objectToPick)
            {

                if (Vector3.Distance(transform.position, objectToPick.transform.position) < 5)
                {

                    if (objectToPick.thisType == PickUpObject.PickUP.Health) { print("Health"); }

                    if (objectToPick.thisType == PickUpObject.PickUP.Key1)
                    {
                        print("Key");
                        GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<enemySpawn>().SendMessage("SpawnEnemy");
                        // SendMessage("SpawnEnemy");
                        Destroy(Key1);
                        gotKey1 = true;

                    }

                    if (objectToPick.thisType == PickUpObject.PickUP.FlashLight)
                    {
                        print("Flashlight");
                        //flashlight.transform.parent = Player.transform;
                        Destroy(flashlight);

                    }

                    if (objectToPick.thisType == PickUpObject.PickUP.Paper) { print("Paper"); }
                }
            }

        }
    }
        public void potatoe()
            {
       
    }

        //if (Vector3.Distance(transform.position, Player.position) < 5)
        //{
        //    CollectableObject.GetComponent<PickUpManager>().KeyCollected();
        //    Destroy(this.gameObject);
        //}



    }

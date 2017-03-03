using UnityEngine;
using System.Collections;
using System;

public class PickUpManager : MonoBehaviour {
    public Transform Player;
    public Transform flashlight;
    public Transform Key;


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
            PickUpObject objectToPick = hitObject.collider.gameObject.GetComponent<PickUpObject>();

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
                        //Destroy(Key);
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


        //if (Vector3.Distance(transform.position, Player.position) < 5)
        //{
        //    CollectableObject.GetComponent<PickUpManager>().KeyCollected();
        //    Destroy(this.gameObject);
        //}



    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour {
    public GameObject enemy;
    public GameObject spawner;
    
	// Use this for initialization
	void Start ()
    {
        
        //Instantiate(enemy, spawner.transform.position, spawner.transform.rotation);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //if()
        //Instantiate(enemy, spawner.transform.position, spawner.transform.rotation);
    }

    public void SpawnEnemy()
    {
        Instantiate(enemy, spawner.transform.position, spawner.transform.rotation);
    }
}

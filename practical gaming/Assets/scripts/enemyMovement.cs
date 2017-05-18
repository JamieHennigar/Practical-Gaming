using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour {

    float enemyWalkingSpeed = 3.0f;
    enum enemyBehavior{ patrol, attack}
    enum enemyTransition { seePlayer, notSeePlayer, nothing}
    enemyBehavior currentBehavior;
    enemyTransition currentTransition;
    public Transform player;
    public Transform monster;
    public Transform[] destinations;
    private int destPoint = 0;
    private NavMeshAgent agent;
	Animator enemyMove;

    // Use this for initialization
    void Start () {
        currentBehavior = enemyBehavior.patrol;
        currentTransition = enemyTransition.nothing;
        agent = GetComponent<NavMeshAgent>();

        agent.destination = destinations[0].position;
		enemyMove = GetComponent<Animator>();


        //player = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        
        switch(currentBehavior)
        {
            case enemyBehavior.patrol:
                
                switch(currentTransition)
                {
                    case
                        enemyTransition.seePlayer:
                        currentBehavior = enemyBehavior.attack;
                        break;
                }
                break;

            case enemyBehavior.attack:
                switch(currentTransition)
                {
                    case enemyTransition.notSeePlayer:
                        currentBehavior = enemyBehavior.patrol;
                        break;
                }
                break;
        }

        switch (currentBehavior)
        {
            
		case enemyBehavior.patrol:
     
			if (agent.remainingDistance < 0.5f)
				
                    GotoNextPoint();

                break;
            case enemyBehavior.attack:
                Vector3 fwd = transform.TransformDirection(Vector3.forward);

                RaycastHit hit;
                if (Physics.Raycast(transform.position, fwd, out hit, 10))
                {
                    
                    if (hit.collider.gameObject.name == "Player")
                    Debug.Log("i see you");
                    transform.LookAt(player.position);
                    transform.Rotate(new Vector3(0, -90, 0), Space.Self);
                    transform.Translate(new Vector3(enemyWalkingSpeed * Time.deltaTime, 0, 0));
                }
                break;
        }
        
    }

    void GotoNextPoint()
    {
       

        
        agent.destination = destinations[destPoint].position;

       
        destPoint = (destPoint + 1) % destinations.Length;
        transform.Translate(new Vector3(enemyWalkingSpeed * Time.deltaTime, 0, 0));
		//enemyMove.SetBool ("walk", true);
		enemyMove.SetFloat("mixamo.com", enemyWalkingSpeed);
    }

}

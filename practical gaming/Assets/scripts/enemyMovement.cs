using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour {

    float enemyWalkingSpeed = 4.0f;
    enum enemyBehavior{ patrol, attack}
    enum enemyTransition { seePlayer, notSeePlayer, nothing}
    enemyBehavior currentBehavior;
    enemyTransition currentTransition;
    public Transform player;
    public Transform[] destinations;
    private int destPoint = 0;
    private NavMeshAgent agent;

    // Use this for initialization
    void Start () {
        currentBehavior = enemyBehavior.patrol;
        currentTransition = enemyTransition.nothing;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
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

        switch(currentBehavior)
        {
            case enemyBehavior.patrol:
                if (agent.remainingDistance < 0.5f)
                    GotoNextPoint();

                break;
            case enemyBehavior.attack:
                transform.LookAt(player.position);
                transform.Rotate(new Vector3(0, -90, 0), Space.Self);
                transform.Translate(new Vector3(enemyWalkingSpeed * Time.deltaTime, 0, 0));
                break;
        }
        
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
       //if (destinations.Length == 0)
          //  return;

        // Set the agent to go to the currently selected destination.
        agent.destination = destinations[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % destinations.Length;
        transform.Translate(new Vector3(enemyWalkingSpeed * Time.deltaTime, 0, 0));
    }

}

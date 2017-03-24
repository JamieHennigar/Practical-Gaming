using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockedDoors : MonoBehaviour {
    public enum doors { lock1, lock2, lock3, lock4, lock5, lock6, lock7, lock8, lock9, lock10 }
    public doors thisDoor;
    public int doornumber;

    Animator doorAnimator;
    // Use this for initialization
    void Start () {

        doorAnimator = GetComponent<Animator>();


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void open()
    {
        print("Open Sesame");
        doorAnimator.SetBool("open", true);

    }

    private void lockNumber()
    {
        
    }
}

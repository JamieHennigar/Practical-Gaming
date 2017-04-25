using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class forrestToHouse : MonoBehaviour {
    bool mouseOver = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey(KeyCode.Mouse0) && mouseOver)
        {
            Debug.Log("load damn you");
            SceneManager.LoadScene("House");
        }
	}

    void OnMouseEnter()
    {
        print("mouse");
        
        mouseOver = true;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    
   // public Text theText;
     //Color OnMouseOverColor = Color.yellow;
    // Color OnMouseClickColor = Color.red;
   //  Color OnMouseExitColor = Color.white;
    // Use this for initialization
    void Start () {
		
	}
   /* void Update()
    {
        OnMouseEnter();
        OnMouseExit();
    }*/

    void OnMouseEnter()
    {
        print("cancer");
        GetComponent<TextMesh>().color = Color.red;
        if(Input.GetKey(KeyCode.Mouse0))
        {
            print("meh");
            SceneManager.LoadScene("forest");
        }
    }
    void OnMouseExit()
    {
        GetComponent<TextMesh>().color = Color.white;
    }

    
    
   /* void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2.5f, Screen.height / 3, Screen.width / 4, Screen.height / 8), "New Game"))
        {
            SceneManager.LoadScene("forest");
        }
        if (GUI.Button(new Rect(Screen.width / 2.5f, Screen.height / 2, Screen.width / 4, Screen.height / 8), "Quit Game"))
        {
            Application.Quit();
        }
    }*/

}

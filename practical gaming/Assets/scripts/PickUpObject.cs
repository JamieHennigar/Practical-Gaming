using UnityEngine;
using System.Collections;

public class PickUpObject : MonoBehaviour {

    public Transform Player;
    

    public enum PickUP { Health, Key, FlashLight, Paper, Damage}

    public PickUP thisType;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
   /* void OnTriggerEnter(Collider objectHit)
    {
        print("Ouch");
        objectHit.gameObject.GetComponent<PickUpManager>().AddHealth(50);
        

    }*/

   
}

using UnityEngine;
using System.Collections;

public class PickUpObject : MonoBehaviour {

    public Transform Player;
    

    //public enum PickUP { Health, Key1, key2, key3, key4, key5, key6, key7, key8, key9, finalKey, FlashLight, Paper, Damage}
    public enum PickUP { Health, Key, FlashLight, Paper, Damage }
    public PickUP thisType;
    public int KeyNumber;  // Value set in inspector
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

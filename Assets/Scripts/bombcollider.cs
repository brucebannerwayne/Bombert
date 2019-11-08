using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//make the player unable to go through the bomb
public class bombcollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="player")
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    }
}

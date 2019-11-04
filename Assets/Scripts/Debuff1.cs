using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff1 : MonoBehaviour {
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Link_0")
        {
            
            collision.gameObject.GetComponent<move>().speed = 3.0f;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Link_0")
        {
            
            collision.gameObject.GetComponent<move>().speed = 5.0f;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

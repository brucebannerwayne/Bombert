using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff2 : MonoBehaviour {
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Link_1")
        {
            collision.gameObject.GetComponent<move2>().speed = 3.0f;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Link_1")
        {
            collision.gameObject.GetComponent<move2>().speed = 5.0f;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

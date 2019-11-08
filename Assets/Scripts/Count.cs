using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//count how much area has player 1 painted
public class Count : MonoBehaviour {
    public int Player1Count = 0;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("counting");
        if(collision.gameObject.tag == "Inktag1")
        {

            Player1Count++;
           // Debug.Log("Counted");
        }
    
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count1 : MonoBehaviour {
    public int Player2Count = 0;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("counting");
        if (collision.gameObject.tag == "Inktag2")
        {
            Player2Count++;
            Debug.Log("Counted");
        }

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

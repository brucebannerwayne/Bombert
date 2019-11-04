using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beexploded : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="fire")
        {
            GameObject.Find("Link_0").gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "fire2")
        {
            Debug.Log("contact");
            GameObject.Find("Link_1").gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
            Debug.Log("contact and destroy");
        }
    }
}

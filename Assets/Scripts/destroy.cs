using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script for bomb's explosion
public class destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("exploded", 1f);
	}
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.GetComponent<AnimEvents>().isexplode == true)
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
	}
    void exploded()
    {
        Destroy(gameObject);
    }
}

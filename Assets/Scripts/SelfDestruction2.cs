using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruction2 : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "fire")
        {
    
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruction : MonoBehaviour {
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "fire2")
        {
            Destroy(gameObject);
        }
    }

}

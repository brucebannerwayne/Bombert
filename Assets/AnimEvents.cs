using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvents : MonoBehaviour {
    public bool dead=false;
    public bool isexplode = false;
    void BeDead()
    {
        dead = true;
    }
    void Explode()
    {
        isexplode = true;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

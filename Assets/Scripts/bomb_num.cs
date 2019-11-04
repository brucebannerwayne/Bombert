using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_num : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name =="Link_0")
        {
            GameObject.Find("Link_0").GetComponent<move>().bomb_num += 1;
            GameObject.Find("GameManager").gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
        else if(collision.gameObject.name == "Link_1")
        {
            GameObject.Find("Link_1").GetComponent<move2>().bomb_num += 1;
            GameObject.Find("GameManager").gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}

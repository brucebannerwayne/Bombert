using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lineralbomb : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)//the function of collectable item Lineral bomb
    {
        if (collision.gameObject.name == "Link_0")
        {
            GameObject.Find("Link_0").GetComponent<move>().lineralBomb += 1;
            GameObject.Find("Link_0").GetComponent<move>().hasLineral = true;
            GameObject.Find("GameManager").gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
        else if (collision.gameObject.name == "Link_1")
        {
            GameObject.Find("Link_1").GetComponent<move2>().lineralBomb += 1;
            GameObject.Find("Link_1").GetComponent<move2>().hasLineral = true;
            GameObject.Find("GameManager").gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}

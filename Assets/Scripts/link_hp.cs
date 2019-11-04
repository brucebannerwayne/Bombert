using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class link_hp : MonoBehaviour {
    public int hp = 1;
    private bool demaged=false;
    public Image a;
    public Image b;
    public int num_monster = 6;
    private float timer = 0f;
    void be_normal()
    {
        this.demaged = false;
        this.GetComponent<SpriteRenderer>().enabled = true;
    }
    void be_demaged()
    {
        timer += 0.1f;
        if(timer>=0.5f)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            if (timer > 1f)
                timer = 0f;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
 //       if (demaged)
 //       {
 //           //be_demaged(); 
 //       }
 //       if(hp==1)
 //       {
 //           a.GetComponent<CanvasGroup>().alpha = 1;
 //           b.GetComponent<CanvasGroup>().alpha = 0;
 //       }
 //       if (hp == 2)
 //       {
 //           a.GetComponent<CanvasGroup>().alpha = 1;
 //           b.GetComponent<CanvasGroup>().alpha = 1;
 //       }
 //       if (hp<=0)
 //       {
 //           a.GetComponent<CanvasGroup>().alpha =0;
 //           b.GetComponent<CanvasGroup>().alpha = 0;
 //       }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (demaged)
            return;

        if (collision.gameObject.tag == "fire"|| collision.gameObject.tag == "fire2" || collision.gameObject.tag == "enemy")
        {
            hp -= 1;
            demaged = true;
            Invoke("be_normal",3f);
        }
    }


}

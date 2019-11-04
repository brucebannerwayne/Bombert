using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animLink : MonoBehaviour {
    private Animator anim;
    public Event beDead;
    private bool isleft=false;
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1; 
        transform.localScale = scale;
    }
    //private bool isWalk = false;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetBool("isWalk", true);
            anim.SetBool("isUp", false);
            anim.SetBool("BackDown",false);
            if (isleft == true)
            {
                Flip();
                isleft = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetBool("BackDown", true);
            anim.SetBool("isUp", false);
            anim.SetBool("isWalk", false);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetBool("isWalk", true);
            anim.SetBool("isUp", false);
            if (isleft == false)
            {
                Flip();
                isleft = true;
            }
            anim.SetBool("BackDown", false);
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetBool("isUp", true);
            anim.SetBool("isWalk", false);
            anim.SetBool("BackDown", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
            anim.SetTrigger("setBomb");

        if (GameObject.Find("GameManager").gameObject.GetComponent<gamemanager>().isdead == true)
        {
            anim.SetBool("Dead", true);
        }
        if (GameObject.Find("GameManager").gameObject.GetComponent<gamemanager>().isdead ==false)
        {
            anim.SetBool("Dead", false);
        }

   



    }
}

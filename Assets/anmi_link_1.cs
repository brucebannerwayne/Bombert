using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anmi_link_1 : MonoBehaviour {
    private Animator anim;
    public Event beDead;
    private bool isleft = false;
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    //private bool isWalk = false;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal_P2") < 0)
        {
            anim.SetBool("isWalk", true);
            anim.SetBool("isUp", false);
            anim.SetBool("BackDown", false);
            if (isleft == true)
            {
                Flip();
                isleft = false;
            }
        }
        if (Input.GetAxisRaw("Vertical_P2") < 0)
        {
            anim.SetBool("BackDown", true);
            anim.SetBool("isUp", false);
            anim.SetBool("isWalk", false);
        }
        if (Input.GetAxisRaw("Horizontal_P2") > 0)
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
        if (Input.GetAxisRaw("Vertical_P2") > 0)
        {
            anim.SetBool("isUp", true);
            anim.SetBool("isWalk", false);
            anim.SetBool("BackDown", false);
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            anim.SetTrigger("setBomb");

        if (GameObject.Find("GameManager").gameObject.GetComponent<gamemanager>().isdead2 == true)
        {
            anim.SetBool("Dead", true);
        }
        if (GameObject.Find("GameManager").gameObject.GetComponent<gamemanager>().isdead2 == false)
        {
            anim.SetBool("Dead", false);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChange : MonoBehaviour {
    public GameObject PlayerGround;
    public GameObject Player2Ground;
    public GameObject blueexplode;
    public GameObject redexplode;
    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    // void Update()
    //{
    //    if (collision.gameObject.tag == "fire" && blueexplode.gameObject.GetComponent<AnimEvents>().isexplode == true)
    //    {
    //        Instantiate(PlayerGround, transform.position, transform.rotation);
    //        GameObject.Find("explode_blue").gameObject.GetComponent<AnimEvents>().isexplode = false;
    //    }
    //    //else if (collision.gameObject.tag == "fire2" /*&& redexplode.gameObject.GetComponent<AnimEvents>().isexplode == true*/)
    //    //{
    //    //    Instantiate(Player2Ground, transform.position, transform.rotation);
    //    //    GameObject.Find("red_explode").gameObject.GetComponent<AnimEvents>().isexplode = false;
    //    //}
    //    //}
    
    private void OnTriggerEnter2D(Collider2D collision)//paint the floor when the bomb explode
    {
        if (collision.gameObject.tag == "fire")
        {
            Invoke("boom_blue", 0.95f);
        }
         else if (collision.gameObject.tag == "fire2" /*&& redexplode.gameObject.GetComponent<AnimEvents>().isexplode == true*/)
        {
            Invoke("boom_red",0.95f);
            //GameObject.Find("red_explode").gameObject.GetComponent<AnimEvents>().isexplode = false;
        }
    }
    void boom_blue()
    {
        Instantiate(PlayerGround, transform.position, transform.rotation);
    }
    void boom_red()
    {
        Instantiate(Player2Ground, transform.position, transform.rotation);
    }


}

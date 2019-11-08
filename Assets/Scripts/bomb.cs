using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script used to control bomb
public class bomb : MonoBehaviour {
    //private float destroytime = 0f;
    public GameObject prefab;
    public int bombs;

    public LayerMask bannedLayer;
    // Use this for initialization
    void Start () {
        Invoke("Explode", 3f);
       
    }
	
	// Update is called once per frame
	void Update () {
        

    }

    void Explode()
    {
        if (GameObject.Find("Link_0").GetComponent<move>().setLineral == true)//activate the lineral bomb
        {
            bombs = GameObject.Find("Link_0").GetComponent<move>().bomb_power;
            bombs += 15;
            Instantiate(prefab, transform.position, transform.rotation);

            StartCoroutine("CreateExplosion", Vector3.left);
            StartCoroutine("CreateExplosion", Vector3.right);
            //GameObject obj = Instantiate(bomb) as GameObject;
            GameObject.Find("Link_0").GetComponent<move>().bomb_num += 1;
            Destroy(gameObject);
            GameObject.Find("Link_0").GetComponent<move>().lineralBomb -= 1;
            GameObject.Find("Link_0").GetComponent<move>().hasLineral = false;
            GameObject.Find("Link_0").GetComponent<move>().setLineral = false;
            GameObject.Find("Main Camera").GetComponent<ScreenShake>().isshakeCamera = true;
        }
   
        else if (GameObject.Find("Link_0").GetComponent<move>().setLineral == false)//create normal bomb
        {
            bombs = GameObject.Find("Link_0").GetComponent<move>().bomb_power;
            Instantiate(prefab, transform.position, transform.rotation);

            StartCoroutine("CreateExplosion", Vector3.up);
            StartCoroutine("CreateExplosion", Vector3.down);
            StartCoroutine("CreateExplosion", Vector3.left);
            StartCoroutine("CreateExplosion", Vector3.right);
            //GameObject obj = Instantiate(bomb) as GameObject;
            GameObject.Find("Link_0").GetComponent<move>().bomb_num += 1;
            GameObject.Find("Main Camera").GetComponent<ScreenShake>().isshakeCamera = true;
            Destroy(gameObject);
        }
    }

    IEnumerator CreateExplosion(Vector3 dir)//count down for the explosion
    {
        for(int i=1; i<bombs;i++)
        {
            Instantiate(prefab, transform.position + i * dir, transform.rotation);
            RaycastHit2D hit;
            Vector2 a = new Vector2(dir.x, dir.y);

            hit = Physics2D.Raycast(transform.position, a, i, bannedLayer);//

            //Debug.Log(hit.collider.name);

            if (hit.collider)
            {
                break;
            }
            //Vector3 a =new Vector3(transform.position.x,transform.position.y,0)
            
               
            }
        yield return null;
        //Debug.Log(123);
    }

}

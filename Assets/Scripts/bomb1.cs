using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//bomb control script for player 2
public class bomb1 : MonoBehaviour {
    public GameObject prefab;
    public int bombs;
    public LayerMask bannedLayer;
    private Transform playerTransform;
    // Use this for initialization
    void Start () {
        Invoke("Explode", 3f);
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("1");
        bool liftBomb = GameObject.Find("Link_1").GetComponent<move2>().haveBomb;
        Debug.Log("liftbomb" + liftBomb);
        while (liftBomb == true)
        {
            Debug.Log("2");

            playerTransform = GameObject.Find("Link_1").transform;
            this.transform.LookAt(playerTransform.position.normalized);
            this.transform.Translate(Vector3.forward * 1 * Time.deltaTime);
            break;
        }
    }
    void Explode()
    {
          if (GameObject.Find("Link_1").GetComponent<move2>().setLineral == true)
        {
            bombs = GameObject.Find("Link_1").GetComponent<move2>().bomb_power;
            bombs += 15;
            Instantiate(prefab, transform.position, transform.rotation);

            StartCoroutine("CreateExplosion", Vector3.left);
            StartCoroutine("CreateExplosion", Vector3.right);
            //GameObject obj = Instantiate(bomb) as GameObject;
            GameObject.Find("Link_1").GetComponent<move2>().bomb_num += 1;
            Destroy(gameObject);
            GameObject.Find("Link_1").GetComponent<move2>().lineralBomb -= 1;
            GameObject.Find("Link_1").GetComponent<move2>().hasLineral = false;
            GameObject.Find("Link_1").GetComponent<move2>().setLineral = false;
            GameObject.Find("Main Camera").GetComponent<ScreenShake>().isshakeCamera = true;
        }
          else if(GameObject.Find("Link_1").GetComponent<move2>().setLineral == false)
        {
            bombs = GameObject.Find("Link_1").GetComponent<move2>().bomb_power;
            Instantiate(prefab, transform.position, transform.rotation);

            StartCoroutine("CreateExplosion", Vector3.up);
            StartCoroutine("CreateExplosion", Vector3.down);
            StartCoroutine("CreateExplosion", Vector3.left);
            StartCoroutine("CreateExplosion", Vector3.right);
            //GameObject obj = Instantiate(bomb) as GameObject;
            GameObject.Find("Link_1").GetComponent<move2>().bomb_num += 1;
            GameObject.Find("Main Camera").GetComponent<ScreenShake>().isshakeCamera = true;
            Destroy(gameObject);
          //  Debug.Log("explode");
        }
     
    }

    IEnumerator CreateExplosion(Vector3 dir)
    {
        for (int i = 1; i < bombs; i++)
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
        
    }
}

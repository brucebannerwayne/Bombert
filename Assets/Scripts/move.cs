using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
    public Vector3 playerposition;
    public float speed;
    public Camera a;
    Rigidbody2D rig;
    public GameObject bomb;
    public LayerMask wallLayer;
    public int bomb_num = 1;
    public int bomb_power = 2;
    public int lineralBomb = 0;
    public bool hasLineral = false;
    public bool setLineral = false;
    // Use this for initialization
    void Start () {
        rig = GetComponent<Rigidbody2D>();
        playerposition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        

        float h = Input.GetAxisRaw("Horizontal_P1");
        float v = Input.GetAxisRaw("Vertical_P1");

        if (h != 0)
            v = 0;
        if(transform.position == playerposition)
        {
            if (h > 0)
            {
                RaycastHit2D hit;
                hit = Physics2D.Raycast(transform.position+0.7f*Vector3.right, Vector2.right,0.3f,wallLayer);
                //if(hit.collider)
                //{
                //    if(hit.collider.tag == "bomb")
                //}
                if(!hit.collider)
                playerposition += new Vector3(1,0, 0);
            }
            else if(h<0)
            {
                RaycastHit2D hit;
                hit = Physics2D.Raycast(transform.position+ 0.7f * Vector3.left, Vector2.left, 0.3f, wallLayer);
                if (!hit.collider)
                    playerposition += new Vector3(-1, 0, 0);
            }
            else if (v > 0)
            {
                RaycastHit2D hit;
                hit = Physics2D.Raycast(transform.position+ 0.7f * Vector3.up, Vector2.up, 0.3f, wallLayer);
                if (!hit.collider)
                    playerposition += new Vector3(0, 1, 0);
            }
            else if (  v < 0)
            {
                RaycastHit2D hit;
                hit = Physics2D.Raycast(transform.position+ 0.7f * Vector3.down, Vector2.down, 0.3f, wallLayer);
                if (!hit.collider)
                    playerposition += new Vector3(0, -1, 0);
            }

        }
        rig.MovePosition(Vector2.MoveTowards(transform.position, playerposition, speed * Time.deltaTime));
        //transform.position = Vector3.Lerp(transform.position, playerposition, speed * Time.deltaTime);

        //if ((transform.position - playerposition).magnitude >0.5f)
        //    return;

        


        if(Input.GetKeyDown(KeyCode.Space)&&bomb_num>0)
        {
            //Mathf.RoundToInt(
            if (hasLineral = true && lineralBomb > 0)
            {
                setLineral = true;
            }
            Vector3 a = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y),0);
            Instantiate(bomb,a,bomb.transform .rotation );
            bomb_num -= 1;
            //obj.transform.position = this.gameObject.transform.position;
        }
    }
}

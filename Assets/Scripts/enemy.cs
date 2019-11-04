using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
    private int direction;
    public Vector3 playerposition;
    public float speed;
    Rigidbody2D rig;
    //public GameObject bomb;
    public LayerMask wallLayer;
    // Use this for initialization
    void Start () {
        rig = GetComponent<Rigidbody2D>();
        playerposition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position == playerposition)
        {
            direction = Random.Range(1, 5);

            RaycastHit2D hit;
            switch (direction)
            {
                case 1:
                    hit = Physics2D.Raycast(transform.position + 0.7f * Vector3.right, Vector2.right, 0.3f, wallLayer);
                    if (!hit.collider)
                    { playerposition += new Vector3(1, 0, 0); }
                    break;
                case 2:
                    hit = Physics2D.Raycast(transform.position + 0.7f * Vector3.left, Vector2.left, 0.3f, wallLayer);
                    if (!hit.collider)
                    { playerposition += new Vector3(-1, 0, 0); }
                    break;
                case 3:
                    hit = Physics2D.Raycast(transform.position + 0.7f * Vector3.up, Vector2.up, 0.3f, wallLayer);
                    if (!hit.collider)
                    { playerposition += new Vector3(0, 1, 0); }
                    break;
                case 4:
                    hit = Physics2D.Raycast(transform.position + 0.7f * Vector3.down, Vector2.down, 0.3f, wallLayer);
                    if (!hit.collider)
                    { playerposition += new Vector3(0, -1, 0); }
                    break;
            }
        }
        rig.MovePosition(Vector2.MoveTowards(transform.position, playerposition, speed * Time.deltaTime));
        //transform.position = Vector3.Lerp(transform.position, playerposition, speed * Time.deltaTime);

        //if ((transform.position - playerposition).magnitude >0.5f)
        //    return;

 
    }
}


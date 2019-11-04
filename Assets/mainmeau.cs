using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class mainmeau : MonoBehaviour {
    public Image a;
    public Image b;
    public Image c;
    public Image d;
    private float timer = 0;
    private bool isguide=false;
	// Use this for initialization
	void Start () {
        a.GetComponent<CanvasGroup>().alpha = 1;
       b.GetComponent<CanvasGroup>().alpha = 0;
        c.GetComponent<CanvasGroup>().alpha = 0;
        d.GetComponent<CanvasGroup>().alpha = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if(isguide==false)
        {
            timer += 0.1f;
            if (timer >= 10f && timer < 15f)
            {
                a.GetComponent<CanvasGroup>().alpha = 0;
                b.GetComponent<CanvasGroup>().alpha = 1;
                c.GetComponent<CanvasGroup>().alpha = 0;
                d.GetComponent<CanvasGroup>().alpha = 0;
            }
            if (timer >= 15f)
            {
                a.GetComponent<CanvasGroup>().alpha = 0;
                b.GetComponent<CanvasGroup>().alpha = 0;
                c.GetComponent<CanvasGroup>().alpha = 1;
                d.GetComponent<CanvasGroup>().alpha = 0;
                if (timer >= 20f)
                    timer = 10f;
            }
        }
       
        if(Input.GetKeyUp(KeyCode.Space))
        {
            isguide = true;
            if(isguide)
            {
                a.GetComponent<CanvasGroup>().alpha = 0;
                b.GetComponent<CanvasGroup>().alpha = 0;
                c.GetComponent<CanvasGroup>().alpha = 0;
                d.GetComponent<CanvasGroup>().alpha = 1;
            }
        }
        if(isguide && Input.GetKeyDown(KeyCode.Space))
                SceneManager.LoadScene(1);



    }
}

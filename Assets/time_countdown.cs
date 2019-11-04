using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class time_countdown : MonoBehaviour {
    public GameObject text;
    public int TotalTime = 60;
    public Image timeup;
    public GameObject counter;
    public GameObject counter1;
    //public Image gameover;
    public GameObject link;
    private int Player1Count;
    private int Player2Count;
    private bool isdead = false;
    public double blue_score;
    public double red_score;
    public Text blue;
    public Text red;
    private double redpercent;
    private double bluepercent;
    public Image bluewin;
    public Image redwin;
    public CanvasGroup wincanvas;
    void Start()
    {
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        while (TotalTime >= 0)
        {
            text.GetComponent<Text>().text = TotalTime.ToString();
            yield return new WaitForSeconds(1);
            TotalTime--;
        }
        isdead = true;
        timeup.GetComponent<CanvasGroup>().alpha = 1;
    }

    void Update()
    {
        isdead = false;
        if(isdead==true)
        {
            Instantiate(counter, transform.position, transform.rotation);
            Instantiate(counter1, transform.position, transform.rotation);
            blue_score = GameObject.FindWithTag("Counter").GetComponent<Count>().Player1Count;
            red_score = GameObject.FindWithTag("Counter1").GetComponent<Count1>().Player2Count;
            
            redpercent = red_score / 0.96;
            bluepercent = blue_score / 0.96;
            double Int = System.Math.Round(redpercent * 10 + 0.5, 0);
            redpercent = Int / 10;
            double Int2 = System.Math.Round(bluepercent * 10 + 0.5, 0);
            bluepercent = Int2 / 10;
            blue.GetComponent<Text>().text = bluepercent.ToString();
            red.GetComponent<Text>().text = redpercent.ToString();
            wincanvas.GetComponent<CanvasGroup>().alpha = 1;
            if(bluepercent>=redpercent)
            {
                bluewin.gameObject.GetComponent<CanvasGroup>().alpha = 1;
                redwin.gameObject.GetComponent<CanvasGroup>().alpha = 0;
            }
            else
            {
                bluewin.gameObject.GetComponent<CanvasGroup>().alpha = 0;
                redwin.gameObject.GetComponent<CanvasGroup>().alpha = 1;
            }
            
            //print(GameObject.FindWithTag("Counter").GetComponent<Count>().Player1Count);
            //print(GameObject.FindWithTag("Counter1").GetComponent<Count1>().Player2Count);
            //gameover.GetComponent<CanvasGroup>().alpha = 1;
            //link.GetComponent<move>().enabled = false;
            GameObject.Find("Link_0").gameObject.GetComponent<move>().enabled = false;
            GameObject.Find("Link_0").gameObject.GetComponent<animLink>().enabled = false;
            GameObject.Find("Link_1").gameObject.GetComponent<move2>().enabled = false;
            GameObject.Find("Link_1").gameObject.GetComponent<anmi_link_1>().enabled = false;
            GameObject.Find("Main Camera").gameObject.GetComponent<AudioSource>().Play();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("hhhhhh");
                SceneManager.LoadScene(3 - SceneManager.GetActiveScene().buildIndex);
            }
           
        }

    }


}

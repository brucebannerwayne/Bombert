using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gamemanager : MonoBehaviour
{
    public Image end;
    public Image gameover;
    public GameObject link;
    public GameObject link2;
    //private bool start=true;
    public Image countdownpic;
    public Text countdowntext;
    public Text go;
    public Camera cam;
    private float timer = 0f;
    private float timer2 = 0f;
    public bool isdead = false;
    public bool isdead2 = false;
    private bool isstart = false;
    public GameObject[] hazards;
    public int hazardCount;
    public Vector2 spawnValues;
    private Vector2 spawnPosition = Vector2.zero;
    private Quaternion spawnRotation;
    public float spawnWait;
    public float startWait;
    public float wavewait;
    private bool gameOver;
    private bool restart;
    //public GameObject Link1;
    // public GameObject reset;

    // Use this for initialization
    IEnumerator SpawnWaves()//spawn the collectable items randomly on the map
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                spawnPosition.x = Random.Range(-spawnValues.x, spawnValues.x);
                spawnPosition.y = Random.Range(-spawnValues.y, spawnValues.y);
                spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(wavewait);
            if (gameOver)
            {

                restart = true;
                break;
            }
        }
    }
    void Start()
    {
        gameOver = false;
        restart = false;
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {
        //test whether the game is end
        if (int.Parse(countdowntext.text) == 0)
        {
            countdownpic.gameObject.GetComponent<CanvasGroup>().alpha = 0;
            GameObject.Find("Link_0").gameObject.GetComponent<move>().enabled = true;
            GameObject.Find("Link_0").gameObject.GetComponent<animLink>().enabled = true;
            GameObject.Find("Link_1").gameObject.GetComponent<move2>().enabled = true;
            GameObject.Find("Link_1").gameObject.GetComponent<anmi_link_1>().enabled = true;
            GetComponent<time_countdown>().enabled = true;
        }
        else
        {
            countdownpic.fillAmount -= Time.deltaTime;
        }
        if (countdownpic.fillAmount == 0)
        {

            if (int.Parse(countdowntext.text) > 0)
            {
                countdowntext.text = (int.Parse(countdowntext.text) - 1).ToString();
                countdownpic.fillAmount = 1f;
            }
            if (int.Parse(countdowntext.text) == 0)
            {
                countdowntext.gameObject.GetComponent<CanvasGroup>().alpha = 0;
                go.gameObject.GetComponent<CanvasGroup>().alpha = 1;
                isstart = true;
            }
        }
        if (isstart)
        {
            timer2 += 0.1f;
            //Debug.Log(timer2);
            if (timer2 > 8f)
            {
                go.GetComponent<CanvasGroup>().alpha = 0;
                isstart = false;
            }
        }

        if (!GameObject.FindWithTag("enemy"))
        {
            end.GetComponent<CanvasGroup>().alpha = 1;
            //if (Input.GetKeyDown(KeyCode.Space))
            //    SceneManager.LoadScene(0);
        }
        if (link.GetComponent<link_hp>().hp <= 0)//respawn the player when he is killed by the bomb
        {
            //gameover.GetComponent<CanvasGroup>().alpha = 1;
            isdead = true;
            link.GetComponent<move>().enabled = false;
            timer += 0.1f;
            if (GameObject.Find("Link_0").gameObject.GetComponent<AnimEvents>().dead == true)
            {
                link.GetComponent<SpriteRenderer>().enabled = false;
                isdead = false;
                if (timer >30f)
                {
                    link.GetComponent<move>().enabled = true;
                    link.GetComponent<SpriteRenderer>().enabled = true;
                    link.GetComponent<link_hp>().hp = 1;
                    GameObject.Find("Link_0").gameObject.GetComponent<move>().bomb_num = 1;
                    GameObject.Find("Link_0").gameObject.GetComponent<move>().bomb_power =2;
                    timer = 0f;
                    GameObject.Find("Link_0").gameObject.GetComponent<AnimEvents>().dead = false;

                }

            }
            //if (Input.GetKeyDown(KeyCode.Space))
            //        SceneManager.LoadScene(0);
        }
        if (link2.GetComponent<link_hp>().hp <= 0)
        {
            //gameover.GetComponent<CanvasGroup>().alpha = 1;
            isdead2 = true;
            link2.GetComponent<move2>().enabled = false;
            timer += 0.1f;
            if (GameObject.Find("Link_1").gameObject.GetComponent<AnimEvents>().dead == true)
            {
                link2.GetComponent<SpriteRenderer>().enabled = false;
                isdead2 = false;
                if (timer > 30f)
                {
                    link2.GetComponent<move2>().enabled = true;
                    link2.GetComponent<SpriteRenderer>().enabled = true;
                    link2.GetComponent<link_hp>().hp = 1;
                    GameObject.Find("Link_1").gameObject.GetComponent<move2>().bomb_num = 1;
                    GameObject.Find("Link_1").gameObject.GetComponent<move2>().bomb_power =2;
                    timer = 0f;
                    GameObject.Find("Link_1").gameObject.GetComponent<AnimEvents>().dead = false;
                }

            }
            //if (!GameObject.FindWithTag("enemy"))
            //{
            //    end.GetComponent<CanvasGroup>().alpha = 1;
            //    if (Input.GetKeyDown(KeyCode.Space))
            //        SceneManager.LoadScene(0);
            //}

        }
    }
}



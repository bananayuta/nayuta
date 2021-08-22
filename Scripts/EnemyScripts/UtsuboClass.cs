using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuboClass : MonoBehaviour
{
    public float speed;

    public GameObject player;

    public GameObject game;
    GameManager gameManager;

    PlayerManager playerManager;

    public float cameradis;

    public GameObject maincamera;
    public MainCamera maincameracs;

    public bool movecheck;

    public float eat;

    public float utsubotime;

    public float speed2;

    public float UtuboUP;
    // Start is called before the first frame update
    void Start()
    {
        movecheck = true;
        player = GameObject.Find("Player");
        maincamera = GameObject.Find("Main Camera");

        game = GameObject.FindWithTag("GameManager");

        playerManager = player.GetComponent<PlayerManager>();

        gameManager = game.GetComponent<GameManager>();

        maincameracs = maincamera.GetComponent<MainCamera>();

        transform.Rotate(new Vector3(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z - 45));

        Destroy(gameObject, 30);

        speed2 = playerManager.playerspeed;


        utsubotime = 0;

        LevelSpeed();
        //speed = -4.0f;

        
    }

    // Update is called once per frame
    void Update()
    {
        cameradis = maincameracs.sizef;
        NewSystem();
        

        float levelspeed = Time.deltaTime * speed; //基礎速度変数定義
        transform.localPosition = new Vector3(transform.localPosition.x , transform.localPosition.y+ levelspeed);

        eat = playerManager.eat;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (eat >= 30)
            {
                Destroy(gameObject);
            }


        }
    }

    void OldManager()
    {
        UtuboUP = 7.0f - speed2;
        utsubotime += Time.deltaTime;
        if(speed == -4.0f * speed2 /2)
        {
            if (utsubotime > UtuboUP)
            {
                speed = 4.0f * speed2 /2;
                utsubotime = 0.0f;

            }
        }else if(speed == 4.0f * speed2 / 2)
        {
            if (utsubotime > UtuboUP)
            {
                speed = -4.0f * speed2 / 2;
                utsubotime = 0.0f;

            }
        }
    }

    void NewSystem()
    {

        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level1)//レベル1のとき
        {
            utsubotime += Time.deltaTime;
            if (speed == -2.0f)
            {
                if (utsubotime > 6.0)
                {
                    speed = 2.0f;
                    utsubotime = 0.0f;

                }
            }
            else if (speed == 2.0f)
            {
                Displaymove();
                if (utsubotime > 5.7)
                {
                    speed = -2.0f;
                    utsubotime = 0.0f;

                }
            }

        }


        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level2)//レベル2のとき
        {
            utsubotime += Time.deltaTime;
            if (speed == -3.0f)
            {
                if (utsubotime > 5.0)
                {
                    speed = 3.0f;
                    utsubotime = 0.0f;

                }
            }
            else if (speed == 3.0f)
            {
                Displaymove();
                if (utsubotime > 4.8)
                {
                    speed = -3.0f;
                    utsubotime = 0.0f;

                }
            }
        }

        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level3)//レベル3のとき
        {

        
                utsubotime += Time.deltaTime;
                if (speed == -4.0f)
                {
                    if (utsubotime > 4.0)
                    {
                        speed = 4.0f;
                        utsubotime = 0.0f;

                    }
                }
                else if (speed == 4.0f)
                {
                Displaymove();
                if (utsubotime > 3.9)
                    {
                        speed = -4.0f;
                        utsubotime = 0.0f;

                    }
                }
         }

            if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level4)//レベル4のとき
            {
                utsubotime += Time.deltaTime;
                if (speed == -5.0f)
                {
                    if (utsubotime > 3.0)
                    {
                        speed = 5.0f;
                        utsubotime = 0.0f;

                    }
                }
                else if (speed == 5.0f)
                {
                Displaymove();
                if (utsubotime > 3.0)
                    {
                        speed = -5.0f;
                        utsubotime = 0.0f;

                    }
                }

            }

            if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level5)//レベル5のとき
            {
                utsubotime += Time.deltaTime;
                if (speed == -6.0f)
                {
                    if (utsubotime > 2.0)
                    {
                        speed = 6.0f;
                        utsubotime = 0.0f;

                    }
                }
                else if (speed == 6.0f)
                {
                Displaymove();
                if (utsubotime > 2.0)
                    {
                        speed = -6.0f;
                        utsubotime = 0.0f;

                    }
                }

            }
        

    }

    void LevelSpeed()
    {

        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level1)//レベル1のとき
        {
            speed = -2.0f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level2)//レベル1のとき
        {
            speed = -3.0f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level3)//レベル1のとき
        {
            speed = -4.0f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level4)//レベル1のとき
        {
            speed = -5.0f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level5)//レベル1のとき
        {
            speed = -6.0f;
        }

    }


    public void Displaymove()
    {
        if(movecheck == true)
        {
            transform.position = new Vector3(transform.position.x + cameradis, transform.position.y);
            movecheck = false;
        }
        
    }
}






/*      utsubotime += Time.deltaTime;
if (speed == -2.0f)
{
    if (utsubotime > 5.0)
    {
        speed = 2.0f;
        utsubotime = 0.0f;

    }
}
else if (speed == 2.0f)
{
    if (utsubotime > 5.0)
    {
        speed = -2.0f;
        utsubotime = 0.0f;

    }
}*/

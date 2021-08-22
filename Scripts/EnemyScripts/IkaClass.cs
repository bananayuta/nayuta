using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkaClass : MonoBehaviour
{
    public float speed;

    public float Movespeed;

    public float Ikatime;

    public GameObject game;

    GameManager gameManager;



    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("GameManager");

        gameManager = game.GetComponent<GameManager>();

        Destroy(gameObject, 10);

        StartIKASpeed();
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = -2.0f;


        LevelManagerIKA();



        float levelspeed = Time.deltaTime * speed; //基礎速度変数定義
        float ikaspeed = Time.deltaTime * Movespeed;
        transform.localPosition = new Vector3(transform.localPosition.x + levelspeed, transform.localPosition.y + ikaspeed);


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level2 ||
                gameManager.sakana_state == GameManager.SAKANA_STATE.Level3 ||
                gameManager.sakana_state == GameManager.SAKANA_STATE.Level4 ||
                gameManager.sakana_state == GameManager.SAKANA_STATE.Level5)
            {
                Destroy(gameObject);
            }


        }
    }

    void Level1Move()
    {
       
        Ikatime += Time.deltaTime;
        if (Movespeed == -0.5f)
        {
            if (Ikatime > 1.0)
            {
                Movespeed = 0.5f;
                Ikatime = 0.0f;

            }
        }
        else if (Movespeed == 0.5f)
        {
            if (Ikatime > 1.0)
            {
                Movespeed = -0.5f;
                Ikatime = 0.0f;

            }
        }
    }
    void Level2Move()
    {
        
        Ikatime += Time.deltaTime;
        if (Movespeed == -1.0f)
        {
            if (Ikatime > 1.0)
            {
                Movespeed = 1.0f;
                Ikatime = 0.0f;

            }
        }
        else if (Movespeed == 1.0f)
        {
            if (Ikatime > 1.0)
            {
                Movespeed = -1.0f;
                Ikatime = 0.0f;

            }
        }
    }
    void Level3Move()
    {
        
        Ikatime += Time.deltaTime;
        if (Movespeed == -1.5f)
        {
            if (Ikatime > 1.0)
            {
                Movespeed = 1.5f;
                Ikatime = 0.0f;

            }
        }
        else if (Movespeed == 1.5f)
        {
            if (Ikatime > 1.0)
            {
                Movespeed = -1.5f;
                Ikatime = 0.0f;

            }
        }
    }
    void Level4Move()
    {
        
        Ikatime += Time.deltaTime;
        if (Movespeed == -2.0f)
        {
            if (Ikatime > 1.0)
            {
                Movespeed = 2.0f;
                Ikatime = 0.0f;

            }
        }
        else if (Movespeed == 2.0f)
        {
            if (Ikatime > 1.0)
            {
                Movespeed = -2.0f;
                Ikatime = 0.0f;

            }
        }
    }
    void Level5Move()
    {
        
        Ikatime += Time.deltaTime;
        if (Movespeed == -2.0f)
        {
            if (Ikatime > 1.0)
            {
                Movespeed = 2.0f;
                Ikatime = 0.0f;

            }
        }
        else if (Movespeed == 2.0f)
        {
            if (Ikatime > 1.0)
            {
                Movespeed = -2.0f;
                Ikatime = 0.0f;

            }
        }
    }


    public void LevelManagerIKA()
    {
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level1)//レベル1のとき
        {
            Level1Move();
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level2)//レベル1のとき
        {
            Level2Move();
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level3)//レベル1のとき
        {
            Level3Move();
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level4)//レベル1のとき
        {
            Level4Move();
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level5)//レベル1のとき
        {
            Level5Move();
        }
    }

    public void StartIKASpeed()
    {
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level1)//レベル1のとき
        {
            Movespeed = -0.5f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level2)//レベル1のとき
        {
            Movespeed = -1.0f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level3)//レベル1のとき
        {
            Movespeed = -1.5f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level4)//レベル1のとき
        {
            Movespeed = -2.0f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level5)//レベル1のとき
        {
            Movespeed = -2.0f;
        }
    }
}

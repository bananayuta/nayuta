using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjiClass : MonoBehaviour
{
    public float speed;

    public GameObject player;

    public GameObject game;

    GameManager gameManager;

    PlayerManager playerManager;

    public float eat;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        game = GameObject.FindWithTag("GameManager");

        playerManager = player.GetComponent<PlayerManager>();

        gameManager = game.GetComponent<GameManager>();

        

        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {

        LevelManagerAJI();
        

        float levelspeed = Time.deltaTime * speed; //基礎速度変数定義
        transform.localPosition = new Vector3(transform.localPosition.x + levelspeed, transform.localPosition.y);

        eat = playerManager.eat;
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            if (eat > -1)
            {
                Destroy(gameObject);
            }


        }
    }

    public void LevelManagerAJI()
    {
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level1)//レベル1のとき
        {
            speed = -4.0f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level2)//レベル1のとき
        {
            speed = -6.0f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level3)//レベル1のとき
        {
            speed = -8.0f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level4)//レベル1のとき
        {
            speed = -10.0f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level5)//レベル1のとき
        {
            speed = -12.0f;
        }
    }
}

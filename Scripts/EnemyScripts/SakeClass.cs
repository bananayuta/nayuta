using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SakeClass : MonoBehaviour
{
    public float speed;

    public GameObject player;

    PlayerManager playerManager;

    public float eat;

    public GameObject game;
    public GameManager gameManager;

    public float saketime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        game = GameObject.FindWithTag("GameManager");
        gameManager = game.GetComponent<GameManager>();

        playerManager = player.GetComponent<PlayerManager>();

        speed = -1.0f;

        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {

        saketime += Time.deltaTime;

        SakeMove();


        float levelspeed = Time.deltaTime * speed; //基礎速度変数定義
        transform.localPosition = new Vector3(transform.localPosition.x + levelspeed, transform.localPosition.y);

        eat = playerManager.eat;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (eat >= 20)
            {
                Destroy(gameObject);
            }


        }
    }

    public void SakeMove()
    {
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level1)
        {
            if(saketime > 4.0)
            {
                speed = -4.0f;
            }
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level2)
        {
            if (saketime > 3.7)
            {
                speed = -5.0f;
            }
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level3)
        {
            if (saketime > 3.5)
            {
                speed = -6.0f;
            }
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level4)
        {
            if (saketime > 3.0)
            {
                speed = -6.0f;
            }
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level5)
        {
            if (saketime > 2.7)
            {
                speed = -6.0f;
            }
        }
    }
}

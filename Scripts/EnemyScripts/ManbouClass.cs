using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManbouClass : MonoBehaviour
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



        Destroy(gameObject, 20);
    }

    // Update is called once per frame
    void Update()
    {
        speed = -0.7f;

        LevelManagerMANBOU();

        float levelspeed = Time.deltaTime * speed; //基礎速度変数定義
        transform.localPosition = new Vector3(transform.localPosition.x + levelspeed, transform.localPosition.y);

        eat = playerManager.eat;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (eat > 100)
            {
                Destroy(gameObject);
            }


        }
    }

    public void LevelManagerMANBOU()
    {
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level1)//レベル1のとき
        {
            Vector3 localScale = transform.localScale;
                localScale.x = 0.05f;
                localScale.y = 0.05f;
                localScale.z = 0.05f;
                transform.localScale = localScale;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level2)//レベル1のとき
        {
            Vector3 localScale = transform.localScale;
            localScale.x = 0.1f;
            localScale.y = 0.1f;
            localScale.z = 0.1f;
            transform.localScale = localScale;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level3)//レベル1のとき
        {
            Vector3 localScale = transform.localScale;
            localScale.x = 0.15f;
            localScale.y = 0.15f;
            localScale.z = 0.15f;
            transform.localScale = localScale;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level4)//レベル1のとき
        {
            Vector3 localScale = transform.localScale;
            localScale.x = 0.18f;
            localScale.y = 0.18f;
            localScale.z = 0.18f;
            transform.localScale = localScale;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level5)//レベル1のとき
        {
            Vector3 localScale = transform.localScale;
            localScale.x = 0.18f;
            localScale.y = 0.18f;
            localScale.z = 0.18f;
            transform.localScale = localScale;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkaClass : MonoBehaviour
{
    public float speed;

    public float Movespeed;

    public float Ikatime;

    public GameObject player;

    PlayerManager playerManager;

    public float eat;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        playerManager = player.GetComponent<PlayerManager>();

        Destroy(gameObject, 10);

        Movespeed = -1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        speed = -2.0f;

        

        MoveIka();

        float levelspeed = Time.deltaTime * speed; //基礎速度変数定義
        float ikaspeed = Time.deltaTime * Movespeed;
        transform.localPosition = new Vector3(transform.localPosition.x + levelspeed, transform.localPosition.y + ikaspeed);

        eat = playerManager.eat;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (eat > 30)
            {
                Destroy(gameObject);
            }


        }
    }

    void MoveIka()
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
}

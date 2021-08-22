using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SameClass : MonoBehaviour
{
    public float speed;
    public float speed2;
    public GameObject player;

    PlayerManager playerManager;
    

    public float eat;

    public float Sametime;

    //public bool SameSpeedCheck; //実装不明　サメが生成されたときのスピードをチェックする。
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        playerManager = player.GetComponent<PlayerManager>();

        Destroy(gameObject, 10);
        speed2 = playerManager.playerspeed;
    }

    // Update is called once per frame
    void Update()
    {
        speed = speed2 + 8.0f;//playerより8はやい
        Sametime += Time.deltaTime;

        if(Sametime > 2.7)
        {
            speed = speed2; //playerといっしょ
            //speed = playerManager.playerspeed;
            if(Sametime > 3.8)
            {
                speed = speed2 + 10.0f; //playerより10はやい
                
            }
        }

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
                //Destroy(gameObject);
            }


        }
    }
}

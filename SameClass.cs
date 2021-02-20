using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SameClass : MonoBehaviour
{
    public float speed;

    public GameObject player;

    PlayerManager playerManager;

    public float eat;

    public float Sametime;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        playerManager = player.GetComponent<PlayerManager>();

        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        speed = 10.0f;
        Sametime += Time.deltaTime;

        if(Sametime > 2.7)
        {
            speed = 2.0f;
            if(Sametime > 3.8)
            {
                speed = 12.0f;
                
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

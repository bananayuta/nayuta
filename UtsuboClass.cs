using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuboClass : MonoBehaviour
{
    public float speed;

    public GameObject player;

    PlayerManager playerManager;

    public float eat;

    public float utsubotime;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        playerManager = player.GetComponent<PlayerManager>();

        transform.Rotate(new Vector3(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z - 45));

        Destroy(gameObject, 30);

        utsubotime = 0;

        speed = -4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        utsubotime += Time.deltaTime;
        if(speed == -4.0f)
        {
            if (utsubotime > 5.0)
            {
                speed = 4.0f;
                utsubotime = 0.0f;

            }
        }else if(speed == 4.0f)
        {
            if (utsubotime > 5.0)
            {
                speed = -4.0f;
                utsubotime = 0.0f;

            }
        }

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

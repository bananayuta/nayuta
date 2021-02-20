using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EiClass : MonoBehaviour
{
    public float speed;
    public float eispeed;

    public float eitime;

    public int choise;
    public GameObject player;

    PlayerManager playerManager;

    public float eat;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        playerManager = player.GetComponent<PlayerManager>();

        Destroy(gameObject, 10);
        eispeed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        speed = -2.0f;

        Ei();

        float levelspeed = Time.deltaTime * speed; //基礎速度変数定義
        float eieispeed = Time.deltaTime * eispeed;
        transform.localPosition = new Vector3(transform.localPosition.x + levelspeed, transform.localPosition.y + eieispeed);

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

    void Ei()
    {
        eitime += Time.deltaTime;

        if (eitime > 1.0f)
        {
            choise = Random.Range(0, 9);
            if(choise > 7)
            {
                eispeed += 2.0f;
                eitime = 0.0f;

            }else if(choise < 7 && choise > 4)
            {
                eispeed += 1.0f;
                eitime = 0.0f;
            }else if(choise < 4)
            {
                eitime = 0.0f;
            }
        }
    }
}

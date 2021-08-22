using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreatClass : MonoBehaviour
{
    public float speed;

    public GameObject player;

    

    PlayerManager playerManager;

    private float nextTime;
    public float interval = 0.3f;	// 点滅周期
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        playerManager = player.GetComponent<PlayerManager>();

        Destroy(gameObject, 1.2f);

        nextTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        speed = playerManager.playerspeed;
        float levelspeed = Time.deltaTime * speed; //基礎速度変数定義
        transform.localPosition = new Vector3(transform.localPosition.x + levelspeed, transform.localPosition.y);

        if (Time.time > nextTime)
        {
            //this.gameObject.SetActive(false);

            nextTime += interval;
            Debug.Log("test");



        }
    }
}

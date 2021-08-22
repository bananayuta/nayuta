using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaguroManager : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        speed = -8.0f;

        float levelspeed = Time.deltaTime * speed; //基礎速度変数定義
        transform.localPosition = new Vector3(transform.localPosition.x + levelspeed, transform.localPosition.y);
    }



    //プレイヤーとぶつかった際の処理
    //発生処理
}

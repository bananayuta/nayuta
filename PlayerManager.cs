using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //public GameObject player; //プレイヤー箱
    //public float speed; //速度変数箱
    public float eat; //魚を捕食した数

    public float playerspeed;
    public float fallspeed;
    public bool BodyCheck;

    public GameObject GameManager;
    public GameObject PlayerBody;

  

    


    GameManager gameManager;
    //PlayerBody playerBody;
    

    public float hpmax;
    public float hp;
    public float hptime;
    public float intr;

    // Start is called before the first frame update
    void Start()
    {

        eat = 0; //捕食変数初期化


        //speed = 2.0f;

        GameManager = GameObject.Find("GameManager");
        //PlayerBody = GameObject.Find("PlayerBody");


        gameManager = GameManager.GetComponent<GameManager>();
        //playerBody = PlayerBody.GetComponent<PlayerBody>();

        hpmax = 1000;
        hp = 1000;
        intr = 0.1f;




    }

    // Update is called once per frame
    void Update()
    {

        playerspeed = gameManager.playerspeed;
        fallspeed = gameManager.fallspeed;
        //BodyCheck = playerBody.PlayerBodyCheck;
        
        
        float levelspeed = Time.deltaTime * playerspeed; //基礎速度変数定義
        float levelfallspeed = Time.deltaTime * fallspeed;
        transform.localPosition = new Vector3(transform.localPosition.x + levelspeed, transform.localPosition.y + levelfallspeed);
        
        

        OutFlame();
        DamageCheck();

        hptime += Time.deltaTime;

        if(hptime > intr)
        {
            //hp--;
            hptime = 0f;
        }
        if(hp == 0)
        {
            Destroy(gameObject);
        }

        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //プレイ中のみ衝突判定は行わない(負荷対策)
        if (gameObject != null)
        {

            if(col.gameObject.tag == "Aji") //アジ
            {

                if(eat >= 0)
                {
                    eat++;
                    hp += 10.0f;
                    Debug.Log("アジ食べた");
                }
            }

             if (col.gameObject.tag == "Ebi") //エビ
            {

                if (eat >= 0)
                {
                    eat += 1;
                    //hp += 50.0f;
                    Debug.Log("エビ食べた");
                }
                

            }

            if (col.gameObject.tag == "Tai") //タイ
            {
                if (eat < 10)
                {
                    DestroyPlayer();
                    Debug.Log("食べられた");
                }
                else if (eat > 10)
                {
                    eat++;
                    Debug.Log("タイ食べた");
                }
            }
            if (col.gameObject.tag == "Ika") //イカ
            {
                if (eat < 10)
                {
                    DestroyPlayer();
                    Debug.Log("食べられた");
                }
                else if (eat > 10)
                {
                    eat++;
                    Debug.Log("イカ食べた");
                }
            }
            if (col.gameObject.tag == "Sake") //サケ
            {
                if (eat < 20)
                {
                    DestroyPlayer();
                    Debug.Log("食べられた");
                }
                else if (eat > 20)
                {
                    eat++;
                    Debug.Log("サケ食べた");
                }
            }
            if (col.gameObject.tag == "Ei") //エイ
            {
                if (eat < 30)
                {
                    DestroyPlayer();
                    Debug.Log("食べられた");
                }
                else if (eat > 30)
                {
                    eat++;
                    Debug.Log("エイ食べた");
                }
            }
            if (col.gameObject.tag == "Maguro") //マグロ
            {
                if (eat < 40)
                {
                    DestroyPlayer();
                    Debug.Log("食べられた");
                }
                else if (eat > 40)
                {
                    eat++;
                    Debug.Log("マグロ食べた");
                }
            }
            if (col.gameObject.tag == "Utsubo") //ウツボ
            {
                if (eat < 40)
                {
                    DestroyPlayer();
                    Debug.Log("食べられた");
                }
                else if (eat > 40)
                {
                    eat++;
                    Debug.Log("ウツボ食べた");
                }
            }

            if (col.gameObject.tag == "Same") //サメ
            {
                DestroyPlayer();//GameOver
                Debug.Log("サメに食べられた");
            }
            if (col.gameObject.tag == "Manbou") //マンボウ
            {
                DestroyPlayer();//GameOver
                Debug.Log("マンボウに食べられた");
            }

            if (col.gameObject.tag == "Object")
            {
                //DestroyPlayer();//GameOver
                Debug.Log("ぶつかった");
            }
        }
    }

    void DamageCheck()
    {
        if(BodyCheck == true)
        {
            hp -= 1.1f;
        }
    }



    //プレイヤー削除関数 GameOver呼び出し
    void DestroyPlayer()
    {
        Destroy(gameObject);
    }

    //プレイヤーが画面外に出ていかない処理
    void OutFlame()
    {
        if (gameObject != null) //nullチェック。なくても問題ないがつけておく
        {
            if (this.transform.position.y > 4.7)
            {
                DestroyPlayer();
            }
            if (this.transform.position.y < -4.7)
            {
                DestroyPlayer();
            }
        }
    }



    //Todo作成メモ
    //【実装済(他クラス)】スワイプしたとき上下左右に移動
    //カツオと衝突したときの処理
    //岩または地面にぶつかるとゲームオーバー処理
    //【実装済】transformで実装している為、物理計算はできれば走らせたくないです
    //【実装済】自動で横に移動する
    //プレイヤーの進む加速値を上げていく部分を上げていくことで難易度調整1(要検討)

    //現在のゲームシステムメモ
    //プレイヤーの移動はフリックの強さに比例して早く移動できる処理となっている
}


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

    public AudioClip eatSE;
    public AudioClip DeathSE;
    public AudioClip LevelupSE;

    public GameObject game;
    public GameObject PlayerBody;

    public GameManager gameManager;
    public AudioSource audioSource;
    //PlayerBody playerBody;
    

    public float hpmax;
    public float hp;
    public float hptime;
    public float intr;  //HPが減っていく間隔

    // Start is called before the first frame update
    void Start()
    {

        eat = 0; //捕食変数初期化

        


        //speed = 2.0f;

        game = GameObject.Find("GameManager");
        //PlayerBody = GameObject.Find("PlayerBody");


        gameManager = game.GetComponent<GameManager>();
        //playerBody = PlayerBody.GetComponent<PlayerBody>();

        hpmax = 1430;
        hp = 1430;
        intr = 1f;


        audioSource = gameManager.GetComponent<AudioSource>();

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
        HpManager();
        DebugCommond();


        hptime += Time.deltaTime;


    }
    void DebugCommond()
    {
        if (Input.GetKeyUp("e"))//”E”キーを話した時一匹食べる
        {
            eat++;
        }
        if (Input.GetKeyUp("h"))
        {
            hp -= 100;
        }

    }

    void HpManager()
    {
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level1)//レベル1のとき
        {
            if (hptime > intr)//1000秒食べないと死ぬ
            {
                hp -= 1f;
                hptime = 0f;
            }
            if (hp < 418)
            {
                DestroyPlayer();
            }

        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level2)//レベル2のとき
        {
            if (hptime > intr)//180秒食べないと死ぬ
            {
                hp -= 6f;
                hptime = 0f;
            }
            if (hp < 418)
            {
                DestroyPlayer();
            }

        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level3)//レベル3のとき
        {
            if (hptime > intr)//60秒食べないと死ぬ
            {
                hp -= 8f;
                hptime = 0f;
            }
            if (hp < 418)
            {
                DestroyPlayer();
            }

        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level4)//レベル4のとき
        {
            if (hptime > intr)//30秒食べないと死ぬ
            {
                hp -= 30f;
                hptime = 0f;
            }
            if (hp < 418)
            {
                DestroyPlayer();
            }

        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level5)//レベル5のとき
        {
            if (hptime > intr)//20秒食べないと死ぬ
            {
                hp -= 50f;
                hptime = 0f;
            }
            if (hp < 418)
            {
                DestroyPlayer();
            }

        }
    }




    void OnTriggerEnter2D(Collider2D col)
    {
        //プレイ中のみ衝突判定は行わない(負荷対策)
        if (gameObject != null)
        {

            if(col.gameObject.tag == "Aji") //アジ
            {

               if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level1 ||
                    gameManager.sakana_state == GameManager.SAKANA_STATE.Level2 ||
                    gameManager.sakana_state == GameManager.SAKANA_STATE.Level3 ||
                    gameManager.sakana_state == GameManager.SAKANA_STATE.Level4 ||
                    gameManager.sakana_state == GameManager.SAKANA_STATE.Level5)
                    {

                    eat++;
                    audioSource.PlayOneShot(eatSE);
                    hp += 5.0f;
                    Debug.Log("アジ食べた");
                }
            }

             if (col.gameObject.tag == "Ebi") //エビ
            {

               if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level1 ||
                    gameManager.sakana_state == GameManager.SAKANA_STATE.Level2 ||
                    gameManager.sakana_state == GameManager.SAKANA_STATE.Level3 ||
                    gameManager.sakana_state == GameManager.SAKANA_STATE.Level4 ||
                    gameManager.sakana_state == GameManager.SAKANA_STATE.Level5)
                {
                    eat++;
                    hp += 5.0f;
                    audioSource.PlayOneShot(eatSE);
                    Debug.Log("エビ食べた");
                }
                

            }

            if (col.gameObject.tag == "Tai") //タイ
            {
                if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level1)
                {
                    DestroyPlayer();
                    Debug.Log("食べられた");
                }
                else if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level2 ||
                         gameManager.sakana_state == GameManager.SAKANA_STATE.Level3 ||
                         gameManager.sakana_state == GameManager.SAKANA_STATE.Level4 ||
                         gameManager.sakana_state == GameManager.SAKANA_STATE.Level5)
                {
                    eat++;
                    hp += 10.0f;
                    audioSource.PlayOneShot(eatSE);
                    Debug.Log("タイ食べた");
                }
            }
            if (col.gameObject.tag == "Ika") //イカ
            {
                if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level1)
                {
                    DestroyPlayer();
                    Debug.Log("食べられた");
                }
                 else if(gameManager.sakana_state == GameManager.SAKANA_STATE.Level2 ||
                         gameManager.sakana_state == GameManager.SAKANA_STATE.Level3 ||
                         gameManager.sakana_state == GameManager.SAKANA_STATE.Level4 ||
                         gameManager.sakana_state == GameManager.SAKANA_STATE.Level5)
                {
                    eat++;
                    hp += 10.0f;
                    audioSource.PlayOneShot(eatSE);
                    Debug.Log("イカ食べた");
                }
            }
            if (col.gameObject.tag == "Sake") //サケ
            {
                if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level1 ||
                    gameManager.sakana_state == GameManager.SAKANA_STATE.Level2)
                {
                    DestroyPlayer();
                    Debug.Log("食べられた");
                }
                else if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level3 ||
                         gameManager.sakana_state == GameManager.SAKANA_STATE.Level4 ||
                         gameManager.sakana_state == GameManager.SAKANA_STATE.Level5)
                {
                    eat++;
                    hp += 15.0f;
                    audioSource.PlayOneShot(eatSE);
                    Debug.Log("サケ食べた");
                }
            }
            if (col.gameObject.tag == "Ei") //エイ
            {
                if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level1 ||
                    gameManager.sakana_state == GameManager.SAKANA_STATE.Level2)
                {
                    DestroyPlayer();
                    Debug.Log("食べられた");
                }
                else if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level3 ||
                         gameManager.sakana_state == GameManager.SAKANA_STATE.Level4 ||
                         gameManager.sakana_state == GameManager.SAKANA_STATE.Level5)
                {
                    eat++;
                    hp += 15.0f;
                    audioSource.PlayOneShot(eatSE);
                    Debug.Log("エイ食べた");
                }
            }
            if (col.gameObject.tag == "Maguro") //マグロ
            {
                if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level1 ||
                    gameManager.sakana_state == GameManager.SAKANA_STATE.Level2 ||
                    gameManager.sakana_state == GameManager.SAKANA_STATE.Level3)
                {
                    DestroyPlayer();
                    Debug.Log("食べられた");
                }
                else if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level4 ||
                         gameManager.sakana_state == GameManager.SAKANA_STATE.Level5)
                {
                    eat++;
                    hp += 20.0f;
                    audioSource.PlayOneShot(eatSE);
                    Debug.Log("マグロ食べた");
                }
            }
            if (col.gameObject.tag == "Utsubo") //ウツボ
            {
                if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level1 ||
                    gameManager.sakana_state == GameManager.SAKANA_STATE.Level2 ||
                    gameManager.sakana_state == GameManager.SAKANA_STATE.Level3)
                {
                    DestroyPlayer();
                    Debug.Log("食べられた");
                }
                else if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level4 ||
                         gameManager.sakana_state == GameManager.SAKANA_STATE.Level5)
                {
                    eat++;
                    hp += 20.0f;
                    audioSource.PlayOneShot(eatSE);
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
                if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level1 ||
                    gameManager.sakana_state == GameManager.SAKANA_STATE.Level2 ||
                    gameManager.sakana_state == GameManager.SAKANA_STATE.Level3 ||
                    gameManager.sakana_state == GameManager.SAKANA_STATE.Level4   )
                {
                    DestroyPlayer();
                    Debug.Log("食べられた");
                }
                else if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level5)
                {
                    eat++;
                    hp += 25.0f;
                    audioSource.PlayOneShot(eatSE);
                    Debug.Log("マンボウ食べた");
                }

                
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
        audioSource.PlayOneShot(DeathSE);
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

     /*if (gameManager.sakana_state == GameManager.SAKANA_STATE.WAKANA3 ||
                    gameManager.sakana_state == GameManager.SAKANA_STATE.WAKANA2 ||
                    gameManager.sakana_state == GameManager.SAKANA_STATE.WAKANA1 ||
                    gameManager.sakana_state == GameManager.SAKANA_STATE.WAKANA ||
                    gameManager.sakana_state == GameManager.SAKANA_STATE.HAMACHI3)*/
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement; //シーンマネージャーを使う為に必要

public class GameManager : MonoBehaviour
{
    public float distance;//距離変数箱
    public GameObject startpos;//スタート地点の箱
    public GameObject playerpos;//現在プレイヤーの位置の箱

    public GameObject player; //プレイヤーの箱

    public Text highScoreText; //ハイスコアを表示するText
    public float highScore; //ハイスコア用変数
    public Text thisScoreText; //今回のスコアを表示するText
    public float thisScore; //今回のスコアを表示するText

    public float playerspeed;
    public float fallspeed;
    public float fallintervel;
    public float falltime;
    public float falltime2;
    public float fallintervel2;
    public bool playertouch;

 
    public bool Level2PlayerCheck;
    public bool Level3PlayerCheck;

    Number number;



    //public float Speed;//上昇下降スピード
    public float SpeedTime;

    public float PlayerCheckTime;
    public float PlayerFallTime;

    public float interval1;
    public float interval2;
    public float PlayerCheckInterval;
    public float PlayerFallInterval;

    public bool PlayerClickButton;

    public Text eatText; //食べた魚Text
    public Text sizeText; //サイズText
    private string key = "HIGH SCORE"; //ハイスコアの保存先キー
    //public float infreshon = distance * 0.5; //距離のインフレ対策、実装しなくてもいい
    public GameObject score_object = null; // Textオブジェクト
    public float score_num = 0;

    public GameObject textGameOver;		// 「ゲームオーバー」テキスト
    public GameObject retrybutton;			// Retry操作ボタン
    public GameObject menubutton;			// Menu操作ボタン
    public GameObject HighScore;            // ハイスコア箱
    public GameObject ThisScore;            //今回のスコア箱
    public GameObject EatText;              //食べた魚箱
    public GameObject SizeText;             //プレイヤーの現在のサイズ箱
    public GameObject PauseButton;          //Pauseの箱

    public float playereat;

    PlayerManager playermanager; //PlayerManagerを入れるための箱たぶんわからん
    Transform playertransform; //pppppppp

    public enum SAKANA_STATE
    {
        WAKANA3,
        WAKANA2,
        WAKANA1,
        WAKANA,

        HAMACHI3,
        HAMACHI2,
        HAMACHI1,
        HAMACHI,

        MEJIRO3,
        MEJIRO2,
        MEJIRO1,
        MEJIRO,

        BURI3,
        BURI2,
        BURI1,
        BURI,
        LESENDBURI,

    }

    public SAKANA_STATE sakana_state;



    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll(); //ハイスコアリセット

        /*playerspeed = 2.0f;
        fallspeed = 0.1f;
        fallintervel = 1.0f;
        fallintervel2 = 0.5f;
        playertouch = false;*/

        interval1 = 0.15f;
        playerspeed = 2.0f;
        fallspeed = 0.0f;
        PlayerClickButton = false;
        PlayerCheckInterval = 0.3f;
        PlayerFallInterval = 0.1f;

        Level2PlayerCheck = false;
        Level3PlayerCheck = false;
        

        //SetNumber(0);



        //sakana_state = SAKANA_STATE.WAKANA3;

        highScore = PlayerPrefs.GetFloat(key, 0);
        //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ0になる
        highScoreText.text = "最高距離: " + highScore.ToString() + "m";
        //ハイスコアを表示

        EatText = GameObject.Find("Player");  //EatTextにプレイヤーオブジェクトを入れる草

        playermanager = EatText.GetComponent<PlayerManager>(); //Playerにコンポーネントされているスクリプト<PlayerManager>を呼んで変数に格納
        playertransform = EatText.GetComponent<Transform>(); //pppppppp
        number = EatText.GetComponent<Number>();
    }

    // Update is called once per frame
    void Update()
    {
        

        float dis = Mathf.Floor(distance); //distance変数の小数点を切り捨て
        playereat = playermanager.eat; //PlayerManagerクラスのeat変数を呼び出して格納
        if (playerpos != null)
        {
            distance = Vector2.Distance(startpos.transform.position, playerpos.transform.position);//二点間の距離を計算
            eatText.text = "食べた魚：" + playereat.ToString() + "匹"; //食べた数を表示

            SakanaDisplay();
            LevelUPsakana();
            //FallSpeedManager();
            //FallSpeedtime();

            


            //FallSpeedtime();

            GetInput();
            PLayerClickCheck();
            SpeedManager();
            PLayerClickCheck();
            PlayerFall();

            thisScore = dis;
            thisScoreText.text = "今回の距離：" + thisScore.ToString() + "m";



            // オブジェクトからTextコンポーネントを取得
            Text score_text = score_object.GetComponent<Text>();
            // テキストの表示を入れ替える
            score_text.text = dis + "m";
        }
        //ハイスコアより現在スコアが高い時
        if (dis > highScore)
        {

            highScore = dis;
            //ハイスコア更新

            PlayerPrefs.SetFloat(key, highScore);
            //ハイスコアを保存

            highScoreText.text = "最高距離：" + highScore.ToString() + "m";
            //ハイスコアを表示
        }


        if (playerpos == null) //プレイヤー座標が空になったとき
        {
            GameOver();
        }
    }

    public void GetInput() //プレイヤー操作
    {
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(fallspeed < 0)
                {
                    fallspeed += 1.3f;
                    PlayerClickButton = true;
                }else if(1> fallspeed && fallspeed > 0)
                {
                    Debug.Log("aaaaaa");
                    fallspeed += 0.8f;
                    PlayerClickButton = true;
                }else if (fallspeed > 1)
                {
                    fallspeed += 0.6f;
                    PlayerClickButton = true;
                }


            }
        }
        /*else
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.touches[0];
            }
        }*/

    }

    public void SpeedManager()
    {

        SpeedTime += Time.deltaTime;
        if (SpeedTime > interval1)
        {
            fallspeed -= 0.25f;
            SpeedTime = 0.0f;
        }


    }

    public void PLayerClickCheck()
    {
        if (PlayerClickButton == true)
        {
            PlayerCheckTime += Time.deltaTime;

            if (PlayerCheckTime > PlayerCheckInterval)
            {
                PlayerClickButton = false;
                PlayerCheckTime = 0.0f;

            }

        }

    }

    public void PlayerFall()
    {
        if (PlayerClickButton == false)
        {
            if (fallspeed > 0.0f)
            {
                PlayerFallTime += Time.deltaTime;
                if (PlayerFallTime > PlayerFallInterval)
                {
                    fallspeed -= 0.25f;
                    PlayerFallTime = 0.0f;

                }
            }if(fallspeed < 0.0f)
            {
                PlayerFallTime += Time.deltaTime;
                if (PlayerFallTime > PlayerFallInterval)
                {
                    fallspeed -= 0.1f;
                    PlayerFallTime = 0.0f;

                }

            }

        }
    }



    public void SakanaDisplay()
    {

        if (sakana_state == SAKANA_STATE.WAKANA3)
        {
            sizeText.text = "三級ワカナ" + playereat.ToString() + "cm";
        }
        if (sakana_state == SAKANA_STATE.WAKANA2)
        {
            sizeText.text = "二級ワカナ" + playereat.ToString() + "cm";
        }
        if (sakana_state == SAKANA_STATE.WAKANA1)
        {
            sizeText.text = "一級ワカナ" + playereat.ToString() + "cm";
        }
        if (sakana_state == SAKANA_STATE.WAKANA)
        {
            sizeText.text = "特上ワカナ" + playereat.ToString() + "cm";
        }
        if (sakana_state == SAKANA_STATE.HAMACHI3)
        {
            sizeText.text = "三級ハマチ" + playereat.ToString() + "cm";
        }
        if (sakana_state == SAKANA_STATE.HAMACHI2)
        {
            sizeText.text = "二級ハマチ" + playereat.ToString() + "cm";
        }
        if (sakana_state == SAKANA_STATE.HAMACHI1)
        {
            sizeText.text = "一級ハマチ" + playereat.ToString() + "cm";
        }
        if (sakana_state == SAKANA_STATE.HAMACHI)
        {
            sizeText.text = "特上ハマチ" + playereat.ToString() + "cm";
        }
        if (sakana_state == SAKANA_STATE.MEJIRO3)
        {
            sizeText.text = "三級メジロ" + playereat.ToString() + "cm";
        }
        if (sakana_state == SAKANA_STATE.MEJIRO2)
        {
            sizeText.text = "二級メジロ" + playereat.ToString() + "cm";
        }
        if (sakana_state == SAKANA_STATE.MEJIRO1)
        {
            sizeText.text = "一級メジロ" + playereat.ToString() + "cm";
        }
        if (sakana_state == SAKANA_STATE.MEJIRO)
        {
            sizeText.text = "特上メジロ" + playereat.ToString() + "cm";
        }
        if (sakana_state == SAKANA_STATE.BURI3)
        {
            sizeText.text = "三級ブリ" + playereat.ToString() + "cm";
        }
        if (sakana_state == SAKANA_STATE.BURI2)
        {
            sizeText.text = "二級ブリ" + playereat.ToString() + "cm";
        }
        if (sakana_state == SAKANA_STATE.BURI1)
        {
            sizeText.text = "一級ブリ" + playereat.ToString() + "cm";
        }
        if (sakana_state == SAKANA_STATE.BURI)
        {
            sizeText.text = "特上ブリ" + playereat.ToString() + "cm";
        }
        if (sakana_state == SAKANA_STATE.LESENDBURI)
        {
            sizeText.text = "最高級ブリ" + playereat.ToString() + "cm";
        }
    }

    //ゲームオーバー処理
    public void GameOver()
    {
        textGameOver.SetActive(true); //非表示から表示
        retrybutton.SetActive(true); //非表示から表示
        menubutton.SetActive(true); //非表示から表示
        HighScore.SetActive(true); //非表示から表示
        ThisScore.SetActive(true); //非表示から表示
        PauseButton.SetActive(false); //表示から非表示


    }

    public void LevelUPsakana()//現在のサイズに応じてサカナのステータスが変化する関数
    {
        if (playerpos != null)
        {
            if (10 >= playereat　&& playereat >=0) //水
            {
                sakana_state = SAKANA_STATE.WAKANA3;
                number.SetNumber(0);
            
            }
            else if (20 >= playereat && playereat >= 10)//青
            {
                sakana_state = SAKANA_STATE.WAKANA2;

                number.SetNumber(1);
                playerspeed = 3.0f;
                /*if (Level2PlayerCheck == false)
                {
                    number.SetNumber(1);
                    Level2PlayerCheck = true;
                }*/

            }
            else if (30 >= playereat && playereat >= 20)//紫
            {
                sakana_state = SAKANA_STATE.WAKANA1;
                if (Level3PlayerCheck == false)
                {
                    number.SetNumber(2);
                    playerspeed = 4.0f;
                    Level3PlayerCheck = true;
                }
                
            }
            else if(40 >= playereat && playereat >= 30)//赤
            {
                sakana_state = SAKANA_STATE.WAKANA;
                number.SetNumber(3);
                playerspeed = 5.0f;
            }
            else if (50 >= playereat && playereat >= 40)//金
            {
                sakana_state = SAKANA_STATE.HAMACHI3;
                number.SetNumber(4);
                playerspeed = 6.0f;
                /*Vector3 localScale = playertransform.localScale;
                localScale.x = -0.14f;
                localScale.y = 0.14f;
                localScale.z = 0.14f;
                playertransform.localScale = localScale;*/
            }
            else if (42.5 >= playereat && playereat >= 20)
            {
                sakana_state = SAKANA_STATE.HAMACHI2;
                
            }
            else if (50 >= playereat && playereat >= 42.5)
            {
                sakana_state = SAKANA_STATE.HAMACHI1;
            }
            else if (60 >= playereat && playereat >= 50)
            {
                sakana_state = SAKANA_STATE.HAMACHI;
            }
            else if (65 >= playereat && playereat >= 60)
            {
                sakana_state = SAKANA_STATE.MEJIRO3;
                Vector3 localScale = playertransform.localScale;
                localScale.x = -0.21f;
                localScale.y = 0.21f;
                localScale.z = 0.21f;
                playertransform.localScale = localScale;
            }
            else if (70 >= playereat && playereat >= 65)
            {
                sakana_state = SAKANA_STATE.MEJIRO2;
            }
            else if (75 >= playereat && playereat >= 70)
            {
                sakana_state = SAKANA_STATE.MEJIRO1;
            }
            else if (80 >= playereat && playereat >= 75)
            {
                sakana_state = SAKANA_STATE.MEJIRO;
            }
            else if (85 >= playereat && playereat >= 80)
            {
                sakana_state = SAKANA_STATE.BURI3;
                Vector3 localScale = playertransform.localScale;
                localScale.x = -0.28f;
                localScale.y = 0.28f;
                localScale.z = 0.28f;
                playertransform.localScale = localScale;
            }
            else if (90 >= playereat && playereat >= 85)
            {
                sakana_state = SAKANA_STATE.BURI2;
            }
            else if (95 >= playereat && playereat >= 90)
            {
                sakana_state = SAKANA_STATE.BURI1;
            }
            else if (99.99 >= playereat && playereat >= 95)
            {
                sakana_state = SAKANA_STATE.BURI;
            }
            else if (playereat >= 100)
            {
                sakana_state = SAKANA_STATE.LESENDBURI;
                Vector3 localScale = playertransform.localScale;
                localScale.x = -0.35f;
                localScale.y = 0.35f;
                localScale.z = 0.35f;
                playertransform.localScale = localScale;
            }


            
        }
    }
    //シーン移行処理
    //【実装済】プレイヤーの移動した距離を算出して画面に表示する処理
    //小数点第1までの表示にしたい
    //空腹ゲージの実装
}



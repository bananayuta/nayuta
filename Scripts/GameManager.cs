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
    public bool playerstarttouch;



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
    public GameObject TapText;

    public float playereat;

    PlayerManager playermanager; //PlayerManagerを入れるための箱たぶんわからん
    public AudioSource source; //audioの箱
    public AudioClip GameBGM; //ゲーム中音声
    public AudioClip SwimSE;

    public enum SAKANA_STATE
    {
        Level1,
        Level2,
        Level3,
        Level4,
        Level5,

    }

    public SAKANA_STATE sakana_state;



    // Start is called before the first frame update
    void Start()
    {

        Application.targetFrameRate = 30;
        //PlayerPrefs.DeleteAll(); //ハイスコアリセット

        Time.timeScale = 0;

        interval1 = 0.15f;
        
        fallspeed = 0.0f;
        PlayerClickButton = false;
        PlayerCheckInterval = 0.3f;
        PlayerFallInterval = 0.1f;


        playertouch = false;


        StartGame();


        highScore = PlayerPrefs.GetFloat(key, 0);
        //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ0になる
        highScoreText.text = "さいこう: " + highScore.ToString() + "m";
        //ハイスコアを表示

        EatText = GameObject.Find("Player");  //EatTextにプレイヤーオブジェクトを入れる草

        playermanager = EatText.GetComponent<PlayerManager>(); //Playerにコンポーネントされているスクリプト<PlayerManager>を呼んで変数に格納
        number = EatText.GetComponent<Number>();
        source = gameObject.GetComponent<AudioSource>(); //audioSourceを弄る為の呼び出し
    }

    // Update is called once per frame
    void Update()
    {
        

        float dis = Mathf.Floor(distance); //distance変数の小数点を切り捨て
        
        if (playerpos != null)
        {
            playereat = playermanager.eat; //PlayerManagerクラスのeat変数を呼び出して格納
            distance = Vector2.Distance(startpos.transform.position, playerpos.transform.position);//二点間の距離を計算
            eatText.text = "たべたさかな：" + playereat.ToString() + "ひき"; //食べた数を表示

            SakanaDisplay();
            LevelUPsakana();
            GetInput();
            PLayerClickCheck();
            SpeedManager();
            StartGame();
            PLayerClickCheck();
            PlayerFall();

            thisScore = dis;
            thisScoreText.text = "きょり：" + thisScore.ToString() + "m";



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

            highScoreText.text = "さいこう：" + highScore.ToString() + "m";
            //ハイスコアを表示
        }


        if (playerpos == null) //プレイヤー座標が空になったとき
        {
            GameOver();
        }
    }

    public void StartGame()
    {
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                TapText.SetActive(false); //非表示から表示
                Time.timeScale = 1;
                playerstarttouch = true;
            }


        }
        else
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.touches[0];
                if (touch.phase == TouchPhase.Began)
                {
                    TapText.SetActive(false); //非表示から表示
                    Time.timeScale = 1;
                    playerstarttouch = true;
                }

            }


        }
    }

    public void GetInput() //プレイヤー操作
    {
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                source.PlayOneShot(SwimSE);
                if (fallspeed < 0)
                {
                    fallspeed += 1.3f;
                    PlayerClickButton = true;
                }else if(1> fallspeed && fallspeed > 0)
                {
                    fallspeed += 0.8f;
                    PlayerClickButton = true;
                }else if (fallspeed > 1)
                {
                    fallspeed += 0.6f;
                    PlayerClickButton = true;
                }


            }
            

            }
        else
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.touches[0];
                if (touch.phase == TouchPhase.Began)
                {
                    source.PlayOneShot(SwimSE);
                    if (fallspeed < 0)
                    {
                        fallspeed += 1.3f;
                        PlayerClickButton = true;
                    }
                    else if (1 > fallspeed && fallspeed > 0)
                    {
                        fallspeed += 0.8f;
                        PlayerClickButton = true;
                    }
                    else if (fallspeed > 1)
                    {
                        fallspeed += 0.6f;
                        PlayerClickButton = true;
                    }
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
            
            SpeedTime = 0.0f;
            if(playerstarttouch == true)
            {
                fallspeed -= 0.25f;
            }
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

        if (sakana_state == SAKANA_STATE.Level1)
        {
            sizeText.text = "ランク1：" + playereat.ToString() + "ひき";
        }
        if (sakana_state == SAKANA_STATE.Level2)
        {
            sizeText.text = "ランク2：" + playereat.ToString() + "ひき";
        }
        if (sakana_state == SAKANA_STATE.Level3)
        {
            sizeText.text = "ランク3：" + playereat.ToString() + "ひき";
        }
        if (sakana_state == SAKANA_STATE.Level4)
        {
            sizeText.text = "ランク4：" + playereat.ToString() + "ひき";
        }
        if (sakana_state == SAKANA_STATE.Level5)
        {
            sizeText.text = "ランクMAX：" + playereat.ToString() + "ひき";
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
    public void LevelUPsakana()//現在のサイズに応じてサカナのステータスが変化する関数 ここの変数で全ての状態が変化するはず
    {
        if (playerpos != null)
        {
            if (30 > playereat　&& playereat >=0) //水
            {
                sakana_state = SAKANA_STATE.Level1;
                playerspeed = 1.5f;
                number.SetNumber(0);
            
            }
            else if (60 > playereat && playereat > 29)//青
            {
                sakana_state = SAKANA_STATE.Level2;

                number.SetNumber(1);
                playerspeed = 2.0f;

            }
            else if (80 > playereat && playereat > 59)//紫
            {
                sakana_state = SAKANA_STATE.Level3;
                    number.SetNumber(2);
                    playerspeed = 2.5f;    
            }
            else if(100 > playereat && playereat > 79)//赤
            {
                sakana_state = SAKANA_STATE.Level4;
                number.SetNumber(3);
                playerspeed = 3.0f;
            }
            else if (10000000 >= playereat && playereat > 99)//金
            {
                sakana_state = SAKANA_STATE.Level5;
                number.SetNumber(4);
                playerspeed = 3.5f;
                
            }            
        }
    }

}



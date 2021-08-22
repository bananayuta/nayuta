using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject AjiPrefab;
    public GameObject EbiPrefab;
    public GameObject TaiPrefab;
    public GameObject IkaPrefab;
    public GameObject SakePrefab;
    public GameObject EiPrefab;
    public GameObject MaguroPrefab;
    public GameObject UtsuboPrefab;
    public GameObject SamePrefab;
    public GameObject ManbouPrefab;

    public GameObject AreatPrefab;

    public bool ManbouPopCheck;
    public float ManbouTime;

    public float cameradis;

    public GameObject maincamera;
    public MainCamera maincameracs;

    public GameObject player; //プレイヤーの箱
    public GameObject game;
    public GameObject gameTimerObj;
    

    public GameManager gameManager;
    public GameTimer gameTimer;

    public GameObject displaycheck;
    DisplayCheck displayScipts;


    public float Ajimin;
    public float Ajimix;

    public float Ebimin;
    public float Ebimix;

    public float Taimin;
    public float Taimix;

    public float Ikamin;
    public float Ikamix;

    public float Sakemin;
    public float Sakemix;

    public float Eimin;
    public float Eimix;

    public float Maguromin;
    public float Maguromix;

    public float Utsubomin;
    public float Utsubomix;

    public float Samemin;
    public float Samemix;

    public float Manboumin;
    public float Manboumix;

    public float Level2OriginalMin;
    public float Level2OriginalMax;

    public float interval; //魚出現間隔
    public float time = 0f;

    public float random;
    public float choose;

    public float timer;//timeを参照
    public float level1time;
    public float level2time;
    public float level3time;
    public float level4time;
    public float level5time;

    public bool LevelReset;
    public bool AutoEnemy;

    public float ipadsize;

    // Start is called before the first frame update
    void Start()
    {
        interval = 2.0f;
        ipadsize = 0.0f;
        displayScipts = displaycheck.GetComponent<DisplayCheck>();

        game = GameObject.FindWithTag("GameManager");
        gameTimerObj = GameObject.Find("GameTimer");


        gameManager = game.GetComponent<GameManager>();
        gameTimer = gameTimerObj.GetComponent<GameTimer>();
        maincameracs = maincamera.GetComponent<MainCamera>();

        LevelReset = false;
        AutoEnemy = true;

        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        cameradis = maincameracs.sizef;
        Debug.Log(cameradis);
        time += Time.deltaTime;

        timer = gameTimer.time; //GameTimerクラスからTimeを参照
        level1time = gameTimer.level1time;
        level2time = gameTimer.level2time;
        level3time = gameTimer.level3time;
        level4time = gameTimer.level4time;
        level5time = gameTimer.level5time;

        if (LevelReset == false)
        {
            EnemySetReset();
            LevelReset = true;
        }
        if (AutoEnemy == true)
        {
            SAKANA_difficulty();
        }
        
        PopCheck();
        DebugEnemyPop();//デバックコマンド。エネミーを出すことができる
        EnemyIntervul();
        DebugCommond();
        IpadCheck();



        if (player != null)
        {
            if (time > interval)
            {

                choose = Random.Range(1, 1000);
                if (Ajimix > choose && choose > Ajimin)
                {
                    GameObject aji = Instantiate(AjiPrefab);//アジ
                    aji.transform.position = new Vector3(player.transform.position.x + 25, Random.Range(-4, 4), 0);
                }
                else if (Ebimix > choose && choose > Ebimin)
                {
                    GameObject ebi = Instantiate(EbiPrefab);//エビ
                    ebi.transform.position = new Vector3(player.transform.position.x + 25, Random.Range(-4, 4), 0);
                }
                else if (Taimix > choose && choose > Taimin)
                {
                    GameObject tai = Instantiate(TaiPrefab);//タイ
                    tai.transform.position = new Vector3(player.transform.position.x + 25, Random.Range(-4, 4), 0);
                }
                else if (Ikamix > choose && choose > Ikamin)
                {
                    GameObject ika = Instantiate(IkaPrefab);//イカ
                    ika.transform.position = new Vector3(player.transform.position.x + 25, Random.Range(-4, 4), 0);
                }
                else if (Sakemix > choose && choose > Sakemin)
                {
                    GameObject sake = Instantiate(SakePrefab);//サケ
                    sake.transform.position = new Vector3(player.transform.position.x + 25, Random.Range(-4, 4), 0);
                }
                else if (Eimix > choose && choose > Eimin)
                {
                    GameObject ei = Instantiate(EiPrefab);//エイ
                    ei.transform.position = new Vector3(player.transform.position.x + 25, Random.Range(-4, -3), 0);
                }
                else if (Maguromix > choose && choose > Maguromin)
                {
                    GameObject maguro = Instantiate(MaguroPrefab);//マグロ
                    maguro.transform.position = new Vector3(player.transform.position.x + 50, Random.Range(-4, 4), 0);
                    GameObject areat = Instantiate(AreatPrefab);//マグロ
                    areat.transform.position = new Vector3(player.transform.position.x + 18.5f - cameradis - ipadsize, maguro.transform.position.y, 0);
                }
                else if (Utsubomix > choose && choose > Utsubomin)
                {
                    GameObject utsubo = Instantiate(UtsuboPrefab);//ウツボ
                    utsubo.transform.position = new Vector3(player.transform.position.x + Random.Range(20, 25) - cameradis - ipadsize, Random.Range(-4, -2), 0);//下にしか生成しない。
                }
                else if (Samemix > choose && choose > Samemin)
                {
                    GameObject same = Instantiate(SamePrefab);//サメ
                    same.transform.position = new Vector3(player.transform.position.x - 25, Random.Range(-4, 3), 0);
                }
                else if (Manboumix > choose && choose > Manboumin)
                {
                    if (ManbouPopCheck == false)
                    {
                        GameObject manbou = Instantiate(ManbouPrefab);//マンボウ
                        manbou.transform.position = new Vector3(player.transform.position.x + 25, Random.Range(-4, 4), 0);
                        ManbouPopCheck = true;
                    }
                }
                else if(Level2OriginalMax > choose && choose > Level2OriginalMin)
                {
                    GameObject aji = Instantiate(AjiPrefab);//アジ
                    aji.transform.position = new Vector3(player.transform.position.x + 25, Random.Range(-4, 4), 0);
                    GameObject ika = Instantiate(IkaPrefab);//イカ
                    ika.transform.position = new Vector3(player.transform.position.x + 25, Random.Range(-4, 4), 0);
                    GameObject ei = Instantiate(EiPrefab);//エイ
                    ei.transform.position = new Vector3(player.transform.position.x + 25, Random.Range(-4, -3), 0);
                    GameObject utsubo = Instantiate(UtsuboPrefab);//ウツボ
                    utsubo.transform.position = new Vector3(player.transform.position.x + Random.Range(20, 25) - cameradis, Random.Range(-4, -2), 0);//下にしか生成しない。
                }

                time = 0f;
            }


        }
    }
    public void IpadCheck()
    {
        if(displayScipts.os_type == DisplayCheck.OS_TYPE.iPad)
        {
            ipadsize = 5.0f;
        }
    }

    public void DebugCommond()
    {
        if (Input.GetKeyUp("p"))//”p”キーを話した時一匹食べる
        {
            if (AutoEnemy == false)

            {
                AutoEnemy = true;
            }
            else if (AutoEnemy == true)
            {
                AutoEnemy = false;
                EnemySetReset();
            }
            
        }
    }

    public void EnemySetReset()
    {
        Ajimin = 0;
        Ajimix = 0;

        Ebimin = 0;
        Ebimix = 0;

        Taimin = 0;
        Taimix = 0;

        Ikamin = 0;
        Ikamix = 0;

        Sakemin = 0;
        Sakemix = 0;

        Eimin = 0;
        Eimix = 0;

        Maguromin = 0;
        Maguromix = 0;

        Utsubomin = 0;
        Utsubomix = 0;

        Samemin = 0;
        Samemix = 0;

        Manboumin = 0;
        Manboumix = 0;
    }

    public void DebugEnemyPop()
    {if (player != null)
        {


            if (Input.GetKeyUp("1"))
            {
                GameObject aji = Instantiate(AjiPrefab);//アジ
                aji.transform.position = new Vector3(player.transform.position.x + 25, Random.Range(-4, 4), 0);
            }
            if (Input.GetKeyUp("2"))
            {
                GameObject ebi = Instantiate(EbiPrefab);//エビ
                ebi.transform.position = new Vector3(player.transform.position.x + 25, Random.Range(-4, 4), 0);
            }
            if (Input.GetKeyUp("3"))
            {
                GameObject tai = Instantiate(TaiPrefab);//タイ
                tai.transform.position = new Vector3(player.transform.position.x + 25, Random.Range(-4, 4), 0);
            }
            if (Input.GetKeyUp("4"))
            {
                GameObject ika = Instantiate(IkaPrefab);//イカ
                ika.transform.position = new Vector3(player.transform.position.x + 25, Random.Range(-4, 4), 0);
            }
            if (Input.GetKeyUp("5"))
            {
                GameObject sake = Instantiate(SakePrefab);//サケ
                sake.transform.position = new Vector3(player.transform.position.x + 25, Random.Range(-4, 4), 0);
            }
            if (Input.GetKeyUp("6"))
            {
                GameObject ei = Instantiate(EiPrefab);//エイ
                ei.transform.position = new Vector3(player.transform.position.x + 25, Random.Range(-4, -3), 0);
            }
            if (Input.GetKeyUp("7"))
            {
                GameObject maguro = Instantiate(MaguroPrefab);//マグロ
                maguro.transform.position = new Vector3(player.transform.position.x + 50, Random.Range(-4, 4), 0);
                GameObject areat = Instantiate(AreatPrefab);//マグロ
                areat.transform.position = new Vector3(player.transform.position.x + 18.5f - cameradis - ipadsize , maguro.transform.position.y, 0);
            }
            if (Input.GetKeyUp("8"))
            {
                GameObject utsubo = Instantiate(UtsuboPrefab);//ウツボ
                utsubo.transform.position = new Vector3(player.transform.position.x + Random.Range(20, 25) - cameradis - ipadsize, Random.Range(-4, -2), 0);//下にしか生成しない。
            }
            if (Input.GetKeyUp("9"))
            {
                GameObject same = Instantiate(SamePrefab);//サメ
                same.transform.position = new Vector3(player.transform.position.x - 25, Random.Range(-4, 3), 0);
            }
            if (Input.GetKeyUp("0"))
            {
                if (ManbouPopCheck == true)//たぶんこれレベル5死ぬやろ笑
                {
                    GameObject maguro = Instantiate(MaguroPrefab);//マグロ
                    maguro.transform.position = new Vector3(player.transform.position.x + 50, Random.Range(-4, 4), 0);
                    GameObject areat = Instantiate(AreatPrefab);//マグロ
                    areat.transform.position = new Vector3(player.transform.position.x + 18, maguro.transform.position.y, 0);
                    GameObject same = Instantiate(SamePrefab);//サメ
                    same.transform.position = new Vector3(player.transform.position.x - 25, Random.Range(-4, 3), 0);
                    GameObject utsubo = Instantiate(UtsuboPrefab);//ウツボ
                    utsubo.transform.position = new Vector3(player.transform.position.x + Random.Range(20, 25), Random.Range(-4, -2), 0);//下にしか生成しない。
                }
                if (ManbouPopCheck == false)
                {
                    GameObject manbou = Instantiate(ManbouPrefab);//マンボウ
                    manbou.transform.position = new Vector3(player.transform.position.x + 25, Random.Range(-4, 4), 0);
                    ManbouPopCheck = true;
                }
            }

        }
    }






    void PopCheck() //マンボウ詰み対策
    {
        if(ManbouPrefab != null)
        {
            ManbouTime += Time.deltaTime;
            if(ManbouTime > 9)
            {
                ManbouPopCheck = false;
                ManbouTime = 0f;
            }
        }
    }

    public void EnemyIntervul()
    {
        if (timer < 75)
        {
            interval = 0.7f;
        }
        if (100 < timer && timer > 170)
        {
            interval = 0.65f;
        }
        if (190 < timer && timer > 200)
        {
            interval = 0.6f;
        }
        if (200 < timer && timer > 201)
        {
            interval = 0.55f;
        }
        if (201 < timer && timer > 230)
        {
            interval = 0.5f;
        }
        if (230 < timer /*&& timer > 180*/)
        {
            interval = 0.45f;
        }
    }

    

    public void SAKANA_difficulty()
    {
        //Debug.Log(gameManager.sakana_state);
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level1)
        {
            
            if (2.5 < level1time && level1time < 8)//チュートリアル難易度、操作に慣れてもらいたい
            {
                Ebimin = 0;//50%
                Ebimix = 500;

                Ajimin = 500;//50%
                Ajimix = 1000;
            }
            else if(8<level1time && level1time < 19)//敵魚のタイやイカに慣れて欲しい
            {
                Ajimin = 0;//40%
                Ajimix = 400;

                Ebimin = 300;//30%
                Ebimix = 700;

                Taimin = 700;//20%
                Taimix = 900;

                Ikamin = 900;//10%
                Ikamix = 1000;            
            }else if(19 < level1time && level1time < 30)//サケ出現
            {
                Ajimin = 0;//30%
                Ajimix = 300;

                Ebimin = 300;//20%
                Ebimix = 500;

                Taimin = 500;//20%
                Taimix = 700;

                Ikamin = 700;//20%
                Ikamix = 900;

                Sakemin = 900;//10%
                Sakemix = 1000;
            }else if(30 < level1time && level1time < 45)//エイ出現、割と強いので出現率低めで長いスパン
            {
                Ajimin = 0;//30%
                Ajimix = 300;

                Ebimin = 300;//20%
                Ebimix = 500;

                Taimin = 500;//20%
                Taimix = 700;

                Ikamin = 700;//15%
                Ikamix = 850;

                Sakemin = 850;//10%
                Sakemix = 950;

                Eimin = 950;//5%
                Eimix = 1000;
            }else if (45 < level1time && level1time < 60)//マグロ出現、マグロの脅威を知る。エイやサケやイカの生成率を下げ調整
            {                                            
                Ajimin = 0;//30%
                Ajimix = 300;

                Ebimin = 300;//20%
                Ebimix = 500;

                Taimin = 500;//10%
                Taimix = 600;

                Ikamin = 600;//10%
                Ikamix = 700;

                Sakemin = 700;//10%
                Sakemix = 800;

                Eimin = 800;//10%
                Eimix = 900;

                Maguromin = 900;//10%
                Maguromix = 1000;
            }
            else if (60 < level1time && level1time < 75)//ウツボがでるけど流石にここまで時間かけるのどうなんかなー
            {                                            
                Ajimin = 0;//30%
                Ajimix = 300;

                Ebimin = 300;//20%
                Ebimix = 500;

                Taimin = 500;//10%
                Taimix = 600;

                Ikamin = 600;//10%
                Ikamix = 700;

                Sakemin = 700;//10%
                Sakemix = 800;

                Eimin = 800;//10%
                Eimix = 900;

                Maguromin = 900;//5%
                Maguromix = 950;

                Utsubomin = 950;//5%
                Utsubomix = 1000;
            }
            else if (75 < level1time)//サメでる。ここまで食わない展開は正直想定してないんで死んでもらって問題ないゲームバランスにする。
            {
                Ajimin = 0;//30%
                Ajimix = 300;

                Ebimin = 300;//20%
                Ebimix = 500;

                Taimin = 500;//10%
                Taimix = 600;

                Ikamin = 600;//5%
                Ikamix = 650;

                Sakemin = 650;//5%
                Sakemix = 700;

                Eimin = 700;//5%
                Eimix = 750;

                Maguromin = 750;//5%
                Maguromix = 800;

                Utsubomin = 800;//5%
                Utsubomix = 850;

                Samemin = 850;//10%
                Samemix = 950;

                Manboumin = 950;//5%
                Manboumix = 1000;
            }




        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level2)
        {


            if (level2time < 5)//ここからは40％程度で潰していく
            {
                LevelReset = false;//変数リセット
                Ajimin = 0;//15%
                Ajimix = 150;

                Ebimin = 150;//15%
                Ebimix = 300;

                Taimin = 300;//30%
                Taimix = 600;

                Ikamin = 600;//30%
                Ikamix = 900;

                
            }
            else if (5 < level2time && level2time < 15)//ここまでは50％で様子見、試験運用やスピードアップにより難易度をあげている
            {
                Ajimin = 0;//15%
                Ajimix = 150;

                Ebimin = 150;//15%
                Ebimix = 300;

                Taimin = 300;//20%
                Taimix = 500;

                Ikamin = 500;//20%
                Ikamix = 700;

                Sakemin = 700;//15%
                Sakemix = 850;

                Eimin = 850;//14%
                Eimix = 990;

                Level2OriginalMin = 990;//1%試験運用笑
                Level2OriginalMax = 1000;


            }
            else if (15 < level2time && level2time < 35)//ウツボマグロ出して本格的につぶす。40％運用
            {                                           
                Ajimin = 0;//10%
                Ajimix = 100;

                Ebimin = 100;//10%
                Ebimix = 200;

                Taimin = 200;//10%
                Taimix = 300;

                Ikamin = 300;//10%
                Ikamix = 400;

                Sakemin = 400;//15%
                Sakemix = 550;

                Eimin = 550;//15%
                Eimix = 700;

                Maguromin = 700;//15%
                Maguromix = 850;

                Utsubomin = 850;//14%
                Utsubomix = 990;

                Level2OriginalMin = 990;//1%試験運用笑
                Level2OriginalMax = 1000;
            }
            else if (35 < level2time && level2time < 70)//いつものカオス。レベル2やからクリアは割と容易でしょう。
            {
                Ajimin = 0;//10%
                Ajimix = 100;

                Ebimin = 100;//10%
                Ebimix = 200;

                Taimin = 200;//10%
                Taimix = 300;

                Ikamin = 300;//10%
                Ikamix = 400;

                Sakemin = 400;//10%
                Sakemix = 500;

                Eimin = 500;//10%
                Eimix = 600;

                Maguromin = 600;//10%
                Maguromix = 700;

                Utsubomin = 700;//10%
                Utsubomix = 800;

                Samemin = 800;//10%
                Samemix = 900;

                Manboumin = 900;//8%
                Manboumix = 990;

                Level2OriginalMin = 980;//2%試験運用笑
                Level2OriginalMax = 1000;
            }
            else if (70 < level2time)//クリアさせる気はない。30％しかない。序盤の難関。
            {
                Ajimin = 0;//10%
                Ajimix = 100;

                Ebimin = 100;//10%
                Ebimix = 200;

                Taimin = 200;//5%
                Taimix = 250;

                Ikamin = 250;//5%
                Ikamix = 300;

                Sakemin = 300;//10%
                Sakemix = 400;

                Eimin = 400;//12%
                Eimix = 520;

                Maguromin = 520;//13%
                Maguromix = 650;

                Utsubomin = 650;//13%
                Utsubomix = 780;

                Samemin = 780;//12%
                Samemix = 900;

                Manboumin = 900;//7%
                Manboumix = 970;

                Level2OriginalMin = 970;//3%試験運用笑
                Level2OriginalMax = 1000;
            }


        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level3)//クリア率60％、食える魚のバランス調整次第
        {
            if (level3time < 20)
            {
                Ajimin = 0;//10%
                Ajimix = 100;

                Ebimin = 100;//10%
                Ebimix = 200;

                Taimin = 200;//10%
                Taimix = 300;

                Ikamin = 300;//10%
                Ikamix = 400;

                Sakemin = 400;//10%
                Sakemix = 500;

                Eimin = 500;//10%
                Eimix = 600;

                Maguromin = 600;//10%
                Maguromix = 700;

                Utsubomin = 700;//10%
                Utsubomix = 800;

                Samemin = 800;//10%
                Samemix = 900;

                Manboumin = 900;//10%
                Manboumix = 1000;
            }
            else if (20 < level3time && level3time < 50)//48%にして難易度調整
            {
                Ajimin = 0;//8%
                Ajimix = 80;

                Ebimin = 80;//8%
                Ebimix = 160;

                Taimin = 160;//8%
                Taimix = 240;

                Ikamin = 240;//8%
                Ikamix = 320;

                Sakemin = 320;//8%
                Sakemix = 400;

                Eimin = 400;//8%
                Eimix = 480;

                Maguromin = 480;//13%
                Maguromix = 610;

                Utsubomin = 610;//13%
                Utsubomix = 740;

                Samemin = 740;//13%
                Samemix = 870;

                Manboumin = 870;//13%
                Manboumix = 1000;

            }
            else if (50 < level3time && level3time < 1000)//48%にして難易度調整
            {
                Ajimin = 0;//8%
                Ajimix = 80;

                Ebimin = 80;//8%
                Ebimix = 160;

                Taimin = 160;//8%
                Taimix = 240;

                Ikamin = 240;//8%
                Ikamix = 320;

                Sakemin = 320;//8%
                Sakemix = 400;

                Eimin = 400;//8%
                Eimix = 480;

                Maguromin = 480;//13%
                Maguromix = 610;

                Utsubomin = 610;//13%
                Utsubomix = 740;

                Samemin = 740;//13%
                Samemix = 870;

                Manboumin = 870;//13%
                Manboumix = 1000;




            }
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level4)
        {

            Ajimin = 0;
            Ajimix = 100;

            Ebimin = 100;
            Ebimix = 200;

            Taimin = 200;
            Taimix = 300;

            Ikamin = 300;
            Ikamix = 400;

            Sakemin = 400;
            Sakemix = 500;

            Eimin = 500;
            Eimix = 600;

            Maguromin = 600;
            Maguromix = 700;

            Utsubomin = 700;
            Utsubomix = 800;

            Samemin = 800;
            Samemix = 900;

            Manboumin = 900;
            Manboumix = 1000;

            
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level5)
        {


            Ajimin = 0;
            Ajimix = 100;

            Ebimin = 100;
            Ebimix = 200;

            Taimin = 200;
            Taimix = 300;

            Ikamin = 300;
            Ikamix = 400;

            Sakemin = 400;
            Sakemix = 500;

            Eimin = 500;
            Eimix = 600;

            Maguromin = 600;
            Maguromix = 700;

            Utsubomin = 700;
            Utsubomix = 800;

            Samemin = 800;
            Samemix = 980;

            Manboumin = 980;
            Manboumix = 1000;

        }
    }

    //基礎っぽいのができたので1000の変数を用意して、確率をどんどんあげていくシステムにしよう
}

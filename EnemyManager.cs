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

    public bool ManbouPopCheck;
    public float ManbouTime;


    public GameObject player; //プレイヤーの箱
    public GameObject game;

    public GameManager gameManager;


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

    public float interval; //魚出現間隔
    public float time = 0f;

    public float random;
    public float choose;

    // Start is called before the first frame update
    void Start()
    {
        interval = 2.0f;

        game = GameObject.Find("GameManager");

        gameManager = game.GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        SAKANA_difficulty();
        PopCheck();

        if (player != null)
        {
            if (time > interval)
            {

                choose = Random.Range(1, 1000);
                if (Ajimix > choose && choose >Ajimin)
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
                    maguro.transform.position = new Vector3(player.transform.position.x + 25, Random.Range(-4, 4), 0);
                }
                else if (Utsubomix > choose && choose > Utsubomin)
                {
                    GameObject utsubo = Instantiate(UtsuboPrefab);//ウツボ
                    utsubo.transform.position = new Vector3(player.transform.position.x + Random.Range(20,25), Random.Range(-4, -2), 0);//下にしか生成しない。
                }
                else if (Samemix > choose && choose > Samemin)
                {
                    GameObject same = Instantiate(SamePrefab);//サメ
                    same.transform.position = new Vector3(player.transform.position.x -25, Random.Range(-4, 3), 0);
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

                time = 0f;
            }

            
        }


    }

    void PopCheck()
    {
        if(ManbouPrefab != null)
        {
            ManbouTime += Time.deltaTime;
            if(ManbouTime > 50)
            {
                ManbouPopCheck = false;
                ManbouTime = 0f;
            }
        }
    }

    public void SAKANA_difficulty()
    {
        Debug.Log(gameManager.sakana_state);
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.WAKANA3)
        {
            Ajimin = 0;
            Ajimix = 100;

            Ebimin = 100;
            Ebimix = 400;

            Taimin = 400;
            Taimix = 500;

            Ikamin = 500;
            Ikamix = 600;

            Sakemin = 600;
            Sakemix = 730;

            Eimin = 7000;
            Eimix = 730;

            Maguromin = 730;
            Maguromix = 770;

            Utsubomin = 770;
            Utsubomix = 880;

            Samemin = 880;
            Samemix = 999;

            Manboumin = 999;
            Manboumix = 1000;
    



            interval = 0.7f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.WAKANA2)
        {
            Ajimin = 0;
            Ajimix = 100;

            Ebimin = 100;
            Ebimix = 300;

            Taimin = 300;
            Taimix = 400;

            Ikamin = 400;
            Ikamix = 500;

            Sakemin = 500;
            Sakemix = 600;

            Eimin = 600;
            Eimix = 700;

            Maguromin = 700;
            Maguromix = 760;

            Utsubomin = 760;
            Utsubomix = 800;

            Samemin = 800;
            Samemix = 900;

            Manboumin = 900;
            Manboumix = 1000;

            interval = 1.0f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.WAKANA1)
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

            interval = 1.0f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.WAKANA)
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

            interval = 1.0f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.HAMACHI3)
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

            interval = 1.0f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.HAMACHI2)
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

            interval = 1.0f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.HAMACHI1)
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

            interval = 1.0f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.HAMACHI)
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

            interval = 1.0f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.MEJIRO3)
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

            interval = 1.0f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.MEJIRO2)
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

            interval = 1.0f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.MEJIRO1)
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

            interval = 1.0f;
        }

        if (gameManager.sakana_state == GameManager.SAKANA_STATE.MEJIRO)
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

            interval = 1.0f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.BURI3)
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

            interval = 1.0f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.BURI2)
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

            interval = 1.0f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.BURI1)
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

            interval = 1.0f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.BURI)
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

            interval = 1.0f;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.LESENDBURI)
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

            interval = 1.0f;
        }
    }

    //基礎っぽいのができたので1000の変数を用意して、確率をどんどんあげていくシステムにしよう
}

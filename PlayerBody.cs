using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    public bool PlayerBodyCheck;



    // Start is called before the first frame update
    void Start()
    {
        PlayerBodyCheck = false;


    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerBodyCheck == true)
        {
            Invoke("BodyCheck", 0.1f);
        }

    }

    void BodyCheck()
    {
        PlayerBodyCheck = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //プレイ中のみ衝突判定は行わない(負荷対策)
        if (gameObject != null)
        {

            if (col.gameObject.tag == "Aji") //アジ
            {
                PlayerBodyCheck = true;
                Debug.Log("OK");
            }
            if (col.gameObject.tag == "Ebi") //エビ
            {
                PlayerBodyCheck = true;
                Debug.Log("OK");
            }
            if (col.gameObject.tag == "Tai") //タイ
            {
                PlayerBodyCheck = true;
                Debug.Log("OK");
            }
            if (col.gameObject.tag == "Ika") //イカ
            {
                PlayerBodyCheck = true;
                Debug.Log("OK");
            }
            if (col.gameObject.tag == "Sake") //サケ
            {
                PlayerBodyCheck = true;
                Debug.Log("OK");
            }
            if (col.gameObject.tag == "Ei") //エイ
            {
                PlayerBodyCheck = true;
                Debug.Log("OK");
            }
            if (col.gameObject.tag == "Maguro") //マグロ
            {
                PlayerBodyCheck = true;
                Debug.Log("OK");
            }
            if (col.gameObject.tag == "Utsubo") //ウツボ
            {
                PlayerBodyCheck = true;
                Debug.Log("OK");
            }
            if (col.gameObject.tag == "Same") //サメ
            {
                PlayerBodyCheck = true;
                Debug.Log("OK");
            }
            if (col.gameObject.tag == "Manbou") //マンボウ
            {
                PlayerBodyCheck = true;
                Debug.Log("OK");
            }



            if (col.gameObject.tag == "Object")
            {
                PlayerBodyCheck = true;
                Debug.Log("OK");
            }

            /*if(PlayerBodyCheck == true)
            {
                if (col.gameObject.tag != "Wakana")
                {
                    PlayerBodyCheck = false;
                    Debug.Log("Good");
                }
                if (col.gameObject.tag != "Hamachi")
                {
                    PlayerBodyCheck = false;
                    Debug.Log("Good");
                }
                if (col.gameObject.tag != "Mejiro")
                {
                    PlayerBodyCheck = false;
                    Debug.Log("Good");
                }
                if (col.gameObject.tag != "Buri")
                {
                    PlayerBodyCheck = false;
                    Debug.Log("Good");
                }
                if (col.gameObject.tag != "Maguro")
                {
                    PlayerBodyCheck = false;
                    Debug.Log("Good");
                }
                if (col.gameObject.tag != "Object")
                {
                    PlayerBodyCheck = false;
                    Debug.Log("Good");
                }
            }*/
        }
    }

}

//多分これだと一回当たるとtrueになっちゃうからfalseになるものを実装する

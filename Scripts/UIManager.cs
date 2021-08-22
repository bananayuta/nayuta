using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

using UnityEngine.SceneManagement;



public class UIManager : MonoBehaviour
{
    float ads;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject textGameOver;		// 「ゲームオーバー」テキスト
    public GameObject retrybutton;			// Retry操作ボタン
    public GameObject menubutton;           // Menu操作ボタン

    //リトライ
    public void Retry()
    {
        ads = Random.Range(0.0f, 10.0f);
        if (ads > 8)
        {
            ShowRewardedAd();
            SceneManager.LoadScene("TitleScene");
            Debug.Log(ads);


        }
        else
        {
            SceneManager.LoadScene("GameScene");
            Debug.Log(ads);
        }


        
    }

    //最初のシーンに戻る
    public void Return()
    {


        ads = Random.Range(0.0f, 10.0f);
        if (ads > 8)
        {
            ShowRewardedAd();
            SceneManager.LoadScene("TitleScene");
            Debug.Log(ads);

        }
        else
        {
            SceneManager.LoadScene("TitleScene");
            Debug.Log(ads);
        }
        

    }

    public void ShowRewardedAd()
    {
        Advertisement.Show();

        Debug.Log("o");
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
            

            Debug.Log("OK");
        }
    }


}





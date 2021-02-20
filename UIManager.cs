using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using UnityEngine.SceneManagement;



public class UIManager : MonoBehaviour
{


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
    public GameObject menubutton;			// Menu操作ボタン
 
    //リトライ
    public void Retry()
    {

        SceneManager.LoadScene("GameScene");

    }

    //最初のシーンに戻る
    public void Return()
    {


        SceneManager.LoadScene("TitleScene");
    }
}

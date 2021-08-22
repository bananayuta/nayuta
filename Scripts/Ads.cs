using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //ゲームIDをAndroidとそれ以外(iOS)で分ける

        string gameID = "4176506";

        //string gameID = "3395905";


        //広告の初期化
        Advertisement.Initialize(gameID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

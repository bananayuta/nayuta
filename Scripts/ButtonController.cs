using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ButtonController : MonoBehaviour
{

	public void Start()
	{
		//ゲームIDをAndroidとそれ以外(iOS)で分ける

		string gameID = "4176506";

		//string gameID = "3395905";


		//広告の初期化
		Advertisement.Initialize(gameID);

		
	}

    public void Update()
    {
		ShowRewardedAd();
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

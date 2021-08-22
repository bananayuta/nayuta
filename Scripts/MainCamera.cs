using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

	public GameObject player;
	public float sizef;
	// Start is called before the first frame update
	public GameObject displayCheck;
	public DisplayCheck displayCheckscript;


	void Start()
	{
		Debug.Log("Screen Width : " + Screen.width);
		Debug.Log("Screen  height: " + Screen.height);
		displayCheckscript = displayCheck.GetComponent<DisplayCheck>();
	}

	// Update is called once per frame
	void Update()
	{

		DisplayGame();
		//if(Screen.height < 1250 && Screen.width < 2210 && Screen.width > 2200)
		//{
		//	sizef = 8.0f;
		//}
		//else if (Screen.height < 1530)
  //      {
		//	sizef = 9.0f;
  //      }
  //      else
  //      {
		//	sizef = 6.0f;
		//}


		//プレイヤーキャラをカメラが追いかけていくようにする
		if (player != null)
		{           //プレイヤーキャラは存在しているか？
					//存在していればカメラポジションを設定

			//カメラポジションを決定
			//現在のプレイヤーのX座標をカメラのX座標に設定

			Vector3 cameraPos = new Vector3(player.transform.position.x + sizef, transform.position.y, transform.position.z);



			//↓後にここをプレイヤーが上下左右しても画面が揺れないようにするor上下左右の幅を生かしたゲームシステムにする
			//今は画面が揺れずにY軸がひたすら突き進む内容のコードで実装
			//
			//カメラが左端を越えて動かないように


			if (cameraPos.x < 0.0f)
			{
				//cameraPos.x = 0.0f;
			}

			//カメラが右端を越えて動かないように
			if (cameraPos.x > 25.6f)
			{
				//cameraPos.x = 25.6f;
			}

			cameraPos.y = 0.0f; //y軸(縦軸)のカメラ移動はしないように固定化

			//カメラポジションを変更
			transform.position = cameraPos;
		}

		//プレイヤーに追尾するカメラ移動処理
	}


	public void DisplayGame()
    {
		if(displayCheckscript.display_type == DisplayCheck.DISPLAY_TYPE.iPhone47)
        {
			sizef = 6.0f;
		}
		if(displayCheckscript.display_type == DisplayCheck.DISPLAY_TYPE.iPhone55)
        {
			sizef = 5.6f;
		}
		if (displayCheckscript.display_type == DisplayCheck.DISPLAY_TYPE.iPhoneX)
		{
			sizef = 6.5f;
		}
		if (displayCheckscript.display_type == DisplayCheck.DISPLAY_TYPE.iPhoneXR)
		{
			sizef = 6.5f;
		}
		if (displayCheckscript.display_type == DisplayCheck.DISPLAY_TYPE.iPhoneXS)
		{
			sizef = 6.5f;
		}
		if (displayCheckscript.display_type == DisplayCheck.DISPLAY_TYPE.iPad97)
		{
			sizef = 4.0f;
		}
		if (displayCheckscript.display_type == DisplayCheck.DISPLAY_TYPE.iPad129)
		{
			sizef = 4.0f;
		}
		if (displayCheckscript.display_type == DisplayCheck.DISPLAY_TYPE.iPad105)
		{
			sizef = 4.0f;
		}
		if (displayCheckscript.display_type == DisplayCheck.DISPLAY_TYPE.iPhone4)
		{
			sizef = 6.0f;
		}
		if (displayCheckscript.display_type == DisplayCheck.DISPLAY_TYPE.iPad97s)
		{
			sizef = 4.5f;
		}


	}
}

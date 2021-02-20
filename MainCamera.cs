using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

	public GameObject player;       //プレイヤーオブジェクト
									// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		//プレイヤーキャラをカメラが追いかけていくようにする
		if (player != null)
		{           //プレイヤーキャラは存在しているか？
					//存在していればカメラポジションを設定

			//カメラポジションを決定
			//現在のプレイヤーのX座標をカメラのX座標に設定
			Vector3 cameraPos = new Vector3(player.transform.position.x + 8.0f, transform.position.y, transform.position.z);

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
}

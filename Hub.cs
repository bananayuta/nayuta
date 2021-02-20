using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hub : MonoBehaviour
{
    public Image m_hpGauge;

    public GameObject player;
    public PlayerManager playerManager;
    public GameObject playerscripts;

    // Start is called before the first frame update
    void Start()
    {
        playerscripts = GameObject.Find("Player");
        playerManager = playerscripts.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーを取得する
        //var Player = player.m_instance;

        //HP のゲージの表示を更新する
        float Hp = playerManager.hp;
        float HpMax = playerManager.hpmax;
        m_hpGauge.fillAmount = (float)Hp / HpMax;


    }
}

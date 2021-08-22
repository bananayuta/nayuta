using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float time;//現在の時間
    public float level1time;
    public float level2time;
    public float level3time;
    public float level4time;
    public float level5time;

    public GameObject game;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.FindWithTag("GameManager");
        gameManager = game.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime; //経過時間記録
        LevelTime();
        if (Input.GetKeyUp("t"))
        {
            time += 10;
        }
    }

    public void LevelTime()
    {
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level1)
        {
            level1time += Time.deltaTime;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level2)
        {
            level2time += Time.deltaTime;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level3)
        {
            level3time += Time.deltaTime;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level4)
        {
            level4time += Time.deltaTime;
        }
        if (gameManager.sakana_state == GameManager.SAKANA_STATE.Level5)
        {
            level5time += Time.deltaTime;
        }
    }


}

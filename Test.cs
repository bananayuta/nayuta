using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float Speed;//上昇下降スピード
    public float SpeedTime;

    public float PlayerCheckTime;
    public float PlayerFallTime;

    public float interval1;
    public float interval2;
    public float PlayerCheckInterval;
    public float PlayerFallInterval;

    public bool PlayerClickButton;



    // Start is called before the first frame update
    void Start()
    {
        interval1 = 1f;
        Speed = 0.0f;
        PlayerClickButton = false;
        PlayerCheckInterval = 1f;
        PlayerFallInterval = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        PLayerClickCheck();
        SpeedManager();
        PLayerClickCheck();
        PlayerFall();
    }

    public void SpeedManager()
    {

        SpeedTime += Time.deltaTime;
        if(SpeedTime > interval1)
        {
            Speed -= 0.1f;
            SpeedTime = 0.0f;
        }


    }

    public void GetInput()
    {
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("aaaaaa");
                Speed += 0.1f;
                PlayerClickButton = true;
              

            }
        }

    }



    public void PLayerClickCheck()
    {
        if(PlayerClickButton == true)
        {
            PlayerCheckTime += Time.deltaTime;

            if (PlayerCheckTime > PlayerCheckInterval)
            {
                PlayerClickButton = false;
                PlayerCheckTime = 0.0f;

            }

        }

    }

    public void PlayerFall()
    {
        if(PlayerClickButton == false)
        {
            if(Speed > 0.0f)
            {
                PlayerFallTime += Time.deltaTime;
                if(PlayerFallTime > PlayerFallInterval)
                {
                    Speed -= 0.1f;
                    PlayerFallTime = 0.0f;

                }
            }

        }
    }

    
}

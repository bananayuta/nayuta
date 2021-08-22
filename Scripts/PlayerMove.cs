using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float falltime;
    public float intervel;

    public float playerspeed;
    public float aaa;
    public float fallspeeda;

    public GameObject GameManager;

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        intervel = 1.7f;
        aaa = 0.8f;

        GameManager = GameObject.Find("GameManager");

        gameManager = GameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        fallspeeda = gameManager.fallspeed;

        falltime += Time.deltaTime;

        FallSpeedtime();

        //GetInput();

        //fallspeed = 0.00f;

        IphoneTouch();

    
    }

    public void GetInput()
    {
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("aaaaaa");
                fallspeeda -= aaa;

            }
        }
        else
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.touches[0];
            }
        }

    }

    public void IphoneTouch()
    {
        if (Application.isEditor)
        {
            if (Input.touchCount > 0)
            {
                fallspeeda -= aaa;
                //Touch touch = Input.touches[0];
            }
        }
    }
    

    public void FallSpeedtime()
    {
        if (falltime > intervel)
        {
           // fallspeed -= 0.1f;
            falltime = 0;
        }


    }
}

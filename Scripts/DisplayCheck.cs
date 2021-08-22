using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCheck : MonoBehaviour
{
    public GameObject back;

    public GameObject back1;

    public GameObject gameobj;
    public GameObject distance;
    public GameObject Hpgauge;
    public GameObject size;
    public GameObject pause;
    public GameObject tap;


    public GameObject gameOver;
    public GameObject eattext;
    public GameObject thiscore;
    public GameObject highscore;
    public GameObject retry;
    public GameObject menu;

    public RectTransform getrect;
    public RectTransform getdistance;
    public RectTransform getHpgauge;
    public RectTransform getsize;
    public RectTransform getpause;
    public RectTransform gettap;





    public RectTransform getgameOver;
    public RectTransform geteattext;
    public RectTransform getthiscore;
    public RectTransform gethighscore;
    public RectTransform getretry;
    public RectTransform getmenu;


    public DISPLAY_TYPE display_type;
    public OS_TYPE os_type;

    public enum DISPLAY_TYPE
    {
        iPhone47,//1334×750
        iPhone55,
        iPhoneX,
        iPhoneXR,
        iPhoneXS,
        iPad97,
        iPad129,
        iPad105,
        iPhone4,
        iPad97s,


    }
    public enum OS_TYPE
    {
        iPhone,
        iPad,
    }



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Screen Width : " + Screen.width);//横
        Debug.Log("Screen  height: " + Screen.height);//縦

        getrect = gameobj.GetComponent<RectTransform>();

        getdistance = distance.GetComponent<RectTransform>();
        getHpgauge = Hpgauge.GetComponent<RectTransform>();
        getsize = size.GetComponent<RectTransform>();
        getpause = pause.GetComponent<RectTransform>();
        gettap = tap.GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {

        DisplaySeach();
        DisplayMode();
        Debug.Log(display_type);

        if (Screen.height < 1250 && Screen.width < 2210 && Screen.width > 2200)
        {

            //back.SetActive(false);

            //back1.SetActive(true);



        }
        else if (Screen.height > 1530)
        {
            //back.SetActive(false);

            //back1.SetActive(true);


        }
        else
        {
            //back.SetActive(true);

            //back1.SetActive(false);



        }

        if (Screen.height > 2000)
        {
            getrect.transform.position = new Vector3(transform.position.x + 517, transform.position.y + 1350);


        }
        if (Screen.height < 2000 && Screen.height > 1660)
        {
            getrect.transform.position = new Vector3(transform.position.x + 150, transform.position.y + 1100);
            getdistance.transform.position = new Vector3(transform.position.x - 650, transform.position.y + 1600);
            gettap.transform.localScale = new Vector3(transform.localScale.x + 1.5f, transform.localScale.y + 1.5f);

        }
        if (Screen.height < 1600 && Screen.height > 1530)
        {
            getrect.transform.position = new Vector3(transform.position.x + 150, transform.position.y + 950);
            getpause.transform.position = new Vector3(transform.position.x + 1000, transform.position.y + 1450);
            getdistance.transform.position = new Vector3(transform.position.x - 750, transform.position.y + 1450);
            gettap.transform.localScale = new Vector3(transform.localScale.x + 1, transform.localScale.y + 1);

        }
        if (Screen.height < 1250 && Screen.width < 2210 && Screen.width > 2200)
        {
            getdistance.transform.position = new Vector3(transform.position.x - 750, transform.position.y + 1200);
            getpause.transform.position = new Vector3(transform.position.x + 1200, transform.position.y + 1150);
            getHpgauge.transform.position = new Vector3(transform.position.x - 0, transform.position.y + 1130);
            getsize.transform.position = new Vector3(transform.position.x + 800, transform.position.y + 1150);
            gettap.transform.localScale = new Vector3(transform.localScale.x + 1.5f, transform.localScale.y + 1.5f);

        }



    }



    public void DisplaySeach()
    {

        if (1335 > Screen.width && Screen.width > 1333 && 751 > Screen.height && Screen.height > 749)
        {
            display_type = DISPLAY_TYPE.iPhone47;
        }
        if (1921 > Screen.width && Screen.width > 1919 && 1081 > Screen.height && Screen.height > 1079)
        {
            display_type = DISPLAY_TYPE.iPhone55;
        }
        if (2437 > Screen.width && Screen.width > 2435 && 1126 > Screen.height && Screen.height > 1124)
        {
            display_type = DISPLAY_TYPE.iPhoneX;
        }
        if (1793 > Screen.width && Screen.width > 1791 && 829 > Screen.height && Screen.height > 827)
        {
            display_type = DISPLAY_TYPE.iPhoneXR;
        }
        if (2689 > Screen.width && Screen.width > 2687 && 1243 > Screen.height && Screen.height > 1241)
        {
            display_type = DISPLAY_TYPE.iPhoneXS;
        }
        if (2049 > Screen.width && Screen.width > 2047 && 1537 > Screen.height && Screen.height > 1535)
        {
            display_type = DISPLAY_TYPE.iPad97;
        }
        if (2733 > Screen.width && Screen.width > 2731 && 2049 > Screen.height && Screen.height > 2047)
        {
            display_type = DISPLAY_TYPE.iPad129;
        }
        if (2225 > Screen.width && Screen.width > 2223 && 1669 > Screen.height && Screen.height > 1667)
        {
            display_type = DISPLAY_TYPE.iPad105;
        }
        if (1137 > Screen.width && Screen.width > 1135 && 641 > Screen.height && Screen.height > 639)
        {
            display_type = DISPLAY_TYPE.iPhone4;
        }
        if (1025 > Screen.width && Screen.width > 1023 && 769 > Screen.height && Screen.height > 767)
        {
            display_type = DISPLAY_TYPE.iPad97s;
        }

    }

    public void DisplayMode()
    {
        if (display_type == DISPLAY_TYPE.iPhone47)
        {
            //getdistance.transform.position = new Vector3(transform.position.x - 450, transform.position.y + 700);
            //getpause.transform.position = new Vector3(transform.position.x + 900, transform.position.y + 650);
            //getHpgauge.transform.position = new Vector3(transform.position.x - 300, transform.position.y + 630);
            //getsize.transform.position = new Vector3(transform.position.x + 500, transform.position.y + 650);


            //getdistance.transform.localScale = new Vector3(transform.localScale.x - 0.2f, transform.localScale.y - 0.2f);
            //getpause.transform.localScale = new Vector3(transform.localScale.x - 0.2f, transform.localScale.y - 0.2f);
            //getHpgauge.transform.localScale = new Vector3(transform.localScale.x - 0.2f, transform.localScale.y - 0.2f);
            //getsize.transform.localScale = new Vector3(transform.localScale.x - 0.2f, transform.localScale.y - 0.2f);


            //gettap.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y);
        }
        if (display_type == DISPLAY_TYPE.iPhone55)
        {

        }
        if (display_type == DISPLAY_TYPE.iPhoneX)
        {


        }
        if (display_type == DISPLAY_TYPE.iPhoneXR)
        {

        }
        if (display_type == DISPLAY_TYPE.iPhoneXS)
        {

        }
        if (display_type == DISPLAY_TYPE.iPad97)
        {
            os_type = OS_TYPE.iPad;
        }
        if (display_type == DISPLAY_TYPE.iPad129)
        {
            os_type = OS_TYPE.iPad;
        }
        if (display_type == DISPLAY_TYPE.iPad105)
        {
            os_type = OS_TYPE.iPad;
        }
        if (display_type == DISPLAY_TYPE.iPhone4)
        {
            //getrect.transform.position = new Vector3(transform.position.x + 517, transform.position.y + 1350);
        }
        if (display_type == DISPLAY_TYPE.iPad97s)
        {

        }
    }




}

    

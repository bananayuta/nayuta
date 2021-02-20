using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string menu = "save";

            switch (menu)
        {
            case "save":
                Debug.Log("保存します");
                break;
            case "open":
                Debug.Log("開きます");
                break;
            case "print":
                Debug.Log("印刷します");
                break;
            default:
                Debug.Log("一致する機能がありません");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

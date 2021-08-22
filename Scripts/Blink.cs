using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{

    //public
    public float speed = 0.5f;

    //private

    private float time;
    public Text text;

 
 

    void Start()
    {
        text = this.gameObject.GetComponent<Text>();

        speed = 0.5f;

        
        

    }

    void Update()
    {
        text.color = GetAlphaColor(text.color);
    }

    //Alpha値を更新してColorを返す
    Color GetAlphaColor(Color color)
    {
        time +=  Time.unscaledDeltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time);
        

        return color;
    }
}

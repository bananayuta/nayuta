using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour
{

    [SerializeField]

    Sprite[] m_sprite = new Sprite[10];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        

    }


    //数字の設定
    public void SetNumber(int num)
    {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = m_sprite[num];
        
        
    }
}

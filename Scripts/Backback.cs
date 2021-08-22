using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backback : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.0f, 0, 0);
        //if (transform.position.x < -9.2f)
        //{
        //    transform.position = new Vector3(9.2f, 0, 0);
        //}
    }
}

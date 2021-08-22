using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource source; //audioの箱

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();

        
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
        
    }

    public void GameOver()
    {
        if(player == null)
        {
            source.Stop();
        }
    }

    //めちゃくちゃ汚いけど直せた。
}

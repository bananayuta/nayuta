using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseManager : MonoBehaviour
{

    [SerializeField]
    //　ポーズした時に表示するUIのプレハブ
    private GameObject pauseUIPrefab;
    //　ポーズUIのインスタンス
    private GameObject pauseUIInstance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPauseButton()
    {
        if(pauseUIInstance == null)
        {
            pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
            Time.timeScale = 0f;
        }
        /*else
        {
            Destroy(pauseUIInstance);
            Time.timeScale = 1f;
        }*/
    }
    

    public void OnResumeButton()
    {
       
            Time.timeScale = 1f;
    
            Destroy(pauseUIPrefab);
        
            
        
    }

    public void OnMenuButton()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScene");
    }

    //EX GameOver時消失
}

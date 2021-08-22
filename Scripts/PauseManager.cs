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

    public GameObject sound;
    public SoundManager soundManager;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        sound = GameObject.Find("SoundManager");
        soundManager = sound.GetComponent<SoundManager>();
        audioSource = soundManager.source;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPauseButton()
    {
        if(pauseUIInstance == null)
        {
            audioSource.Pause();
            pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
            pauseUIInstance.transform.parent = this.transform;
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
        audioSource.UnPause();
        Time.timeScale = 1f;
        Debug.Log("OK");
        Destroy(pauseUIPrefab);
        
            
        
    }

    public void OnMenuButton()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScene");
    }

    //EX GameOver時消失
}

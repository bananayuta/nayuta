using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; //シーンマネージャーを使う為に必要

public class TitleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushStartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void TutorialButton()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void BackTitleButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
}

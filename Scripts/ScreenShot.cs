﻿using UnityEngine;
using System.Collections;

public class ScreenShot : MonoBehaviour
{

    private void Update()
    {
        // スペースキーが押されたら
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // スクリーンショットを保存
            CaptureScreenShot("ScreenShot.png");
        }
    }

    // 画面全体のスクリーンショットを保存する
    private void CaptureScreenShot(string filePath)
    {
        Debug.Log("screenSHoot");
        ScreenCapture.CaptureScreenshot(filePath);
    }

}

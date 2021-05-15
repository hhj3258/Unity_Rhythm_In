using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPause;
    void Start()
    {
        isPause = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            /*일시정지 활성화*/
            if (isPause == false)
            {
                Time.timeScale = 0;
                isPause = true;
                return;
            }

            /*일시정지 비활성화*/
            // 일시정지 비활성화 때 3초 정도 뒤에 다시 시작되는거 구현 & 이미지 필요
            if (isPause == true)
            {
                Time.timeScale = 1;
                isPause = false;
                return;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class Pause : MonoBehaviour
{
    public InputManager im;
    [SerializeField]
    private AudioSource bgm;
    private bool isPause;
    private float time;
    public GameObject[] spriteCnt;

    public AudioSource cntSound;
    int pastTime=3;
    void Awake()
    {
        Time.timeScale = 0;
        isPause = false;
        time = 3;

    }

    void Update()
    {

        // Escape 눌릴 떄 마다 isPause 달라짐
        if (im.pause)
        {
            
            if (isPause == false)
                isPause = true;
            else
            {
                isPause = false;
                pastTime = 3;
                time = 3;
            }
        }
        /*일시정지 비활성화*/
        if (isPause == false && Time.timeScale == 0)
        {
            // 일시정지 3초 뒤 해제
            time -= Time.unscaledDeltaTime;
            // 남은 초 이미지로 표시
            CountDown((int)time);
            if (time < 0)
            {
                Time.timeScale = 1;
                bgm.Play();
                spriteCnt[2].SetActive(false);
                spriteCnt[1].SetActive(false);
                spriteCnt[0].SetActive(false);
            }
        }

        /*일시정지 활성화*/
        if (isPause == true && Time.timeScale==1)
        {
            Time.timeScale = 0;
            bgm.Pause();
        }
    }

    void CountDown(int time)
    {
        if (!spriteCnt[2].activeSelf && !spriteCnt[0].activeSelf)
        {
            spriteCnt[2].SetActive(true);
            spriteCnt[1].SetActive(true);
            spriteCnt[0].SetActive(true);
        }
        //Debug.Log("time : " + time);
        switch (time)
        {
            case 2:
                if (time < pastTime)
                {
                    cntSound.Play();
                    pastTime = time;
                }
                break;
            case 1:
                spriteCnt[2].SetActive(false);
                if (time < pastTime)
                {
                    cntSound.Play();
                    pastTime = time;
                }
                    
                break;
            case 0:
                spriteCnt[1].SetActive(false);
                if (time < pastTime)
                {
                    cntSound.Play();
                    pastTime = time;
                }
                break;
        }
    }
}
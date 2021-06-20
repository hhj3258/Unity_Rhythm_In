using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;

public class Pause : MonoBehaviour
{
    public InputManager im;
    [SerializeField] private AudioSource bgm;
    [SerializeField] private GameObject pauseUI;
    private bool isPause;
    private float time;
    public GameObject[] spriteCnt;
    private bool isReturning;
    bool isButtonClicked;
   

    public AudioSource cntSound;
    int pastTime=3;
    void Awake()
    {
        isButtonClicked = false;
        Time.timeScale = 0;
        isPause = false;
        time = 3;
        isReturning = true;

    }

    void Update()
    {
        // Escape 눌릴 떄 마다 isPause 달라짐
        if (im.pause && isReturning && !PlayerMove.GameOver || isButtonClicked )
        {
            isButtonClicked = false;
            if (isPause == false)
            {
                pauseUI.SetActive(true);
                isPause = true;
            }
            else
            {
                pauseUI.SetActive(false);
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
                isReturning = true;
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
        isReturning = false;
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

    public void Button_Restart()
    {
        LoadingSceneController.LoadingInstance.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Button_Resume()
    {
        isButtonClicked = true;
    }

    public void Button_MainMenu()
    {
        LoadingSceneController.LoadingInstance.LoadScene("MainMenu");
    }
}
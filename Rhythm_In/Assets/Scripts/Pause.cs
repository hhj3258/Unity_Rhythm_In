using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class Pause : MonoBehaviour
{
    public InputManager im;
    [SerializeField]
    private AudioSource audio;
    private bool isPause;
    private float time;
    public TextMeshProUGUI txtCnt;

    void Start()
    {
        isPause = false;
        time = 3;
        txtCnt.gameObject.SetActive(false);
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
                time = 3;
            }
        }
        /*일시정지 비활성화*/
        if (isPause == false && Time.timeScale == 0)
        {
            // 일시정지 3초 뒤 해제
            time -= Time.unscaledDeltaTime;
            // 남은 초 텍스트 표시 
            txtCnt.gameObject.SetActive(true);
            txtCnt.text = ((int)time + 1).ToString();
            if (time < 0)
            {
                Time.timeScale = 1;
                audio.Play();
                txtCnt.gameObject.SetActive(false);
            }
        }

        /*일시정지 활성화*/
        if (isPause == true)
        {

            Time.timeScale = 0;
            audio.Pause();
        }
    }
}
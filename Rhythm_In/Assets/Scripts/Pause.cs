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
        // Escape ���� �� ���� isPause �޶���
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
        Debug.Log(time);
        /*�Ͻ����� ��Ȱ��ȭ*/
        if (isPause == false && Time.timeScale == 0)
        {
            // �Ͻ����� 3�� �� ����
            time -= Time.unscaledDeltaTime;
            // ���� �� �ؽ�Ʈ ǥ�� 
            txtCnt.gameObject.SetActive(true);
            txtCnt.text = ((int)time + 1).ToString();
            if (time < 0)
            {
                Time.timeScale = 1;
                audio.Play();
                txtCnt.gameObject.SetActive(false);
            }
        }

        /*�Ͻ����� Ȱ��ȭ*/
        if (isPause == true)
        {

            Time.timeScale = 0;
            audio.Pause();
        }
    }
}
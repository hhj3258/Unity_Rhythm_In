using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public InputManager im;
    [SerializeField]
    private AudioSource audio;
    private bool isPause;
    void Start()
    {
        isPause = false;
    }

    void Update()
    {
        if (im.pause)
        {
            /*�Ͻ����� Ȱ��ȭ*/
            if (isPause == false)
            {
                audio.Pause();
                Time.timeScale = 0;
                isPause = true;
                return;
            }

            /*�Ͻ����� ��Ȱ��ȭ*/
            // �Ͻ����� ��Ȱ��ȭ �� 3�� ���� �ڿ� �ٽ� ���۵Ǵ°� ���� & �̹��� �ʿ�
            if (isPause == true)
            {
                audio.Play();
                Time.timeScale = 1;
                isPause = false;
                return;
            }
        }
    }
}
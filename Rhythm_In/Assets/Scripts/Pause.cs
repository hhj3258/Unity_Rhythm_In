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
            /*�Ͻ����� Ȱ��ȭ*/
            if (isPause == false)
            {
                Time.timeScale = 0;
                isPause = true;
                return;
            }

            /*�Ͻ����� ��Ȱ��ȭ*/
            // �Ͻ����� ��Ȱ��ȭ �� 3�� ���� �ڿ� �ٽ� ���۵Ǵ°� ���� & �̹��� �ʿ�
            if (isPause == true)
            {
                Time.timeScale = 1;
                isPause = false;
                return;
            }
        }
    }
}
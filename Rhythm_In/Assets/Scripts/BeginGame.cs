using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BeginGame : MonoBehaviour
{
    int cnt;
    public TextMeshProUGUI txtBeginCnt;
    float tempTime;
    int intTime;
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0;
        cnt = 3;
        tempTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        txtBeginCnt.text = cnt.ToString();

        tempTime += Time.unscaledDeltaTime;

        intTime = (int)tempTime;

        switch ((int)tempTime)
        {
            case 1:
                cnt = 3;
                break;
            case 2:
                cnt = 2;
                break;
            case 3:
                cnt = 1;
                break;
        }
        


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class RhythmBar : MonoBehaviour
{
    private GameManager gm;
    public Slider slider;

    [SerializeField] private InputManager im;

    public static bool bpmChange=false;
    //float t = 0;

    private void Start()
    {
        gm = GameManager.Instance;
        //offset = 60f / gm.Bpm1 / 2f;    //ex) bpm=60이라면 0.5초 딜레이

        slider.DOValue(1, 60f / gm.Bpm1).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo).SetDelay(gm.offset * 60f/gm.Bpm1);
    }

    private float nowTime = 0;
    private int tempTime = 0;
    // Update is called once per frame
    void Update()
    {
        //if (bpmChange && slider.value <= 0.01f)
        //{
        //    slider.DOValue(1, 60f / gm.Bpm1).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        //    bpmChange = false;
        //}


        //if (im.attack)
        //    Debug.Log(Time.realtimeSinceStartup);
        //Debug.Log(Time.timeSinceLevelLoad);
        nowTime += Time.deltaTime;

        if ((int)nowTime > tempTime)
        {
            tempTime = (int)nowTime;
            //Debug.Log("slider: " + slider.value);
            
        }
        
        //공격키를 눌렀으며 slider가 0.3보다 크고 0.7보다 작을 때 빨간 색
        if (im.attack && slider.normalizedValue > 0.4f && slider.normalizedValue < 0.6f)
        {
            slider.handleRect.GetComponent<Image>().color = Color.red;
            //Debug.Log("///////////////////중간임");
        }
        else
        {
            slider.handleRect.GetComponent<Image>().color = Color.white;
        }
    }
}

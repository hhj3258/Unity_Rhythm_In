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

    //float t = 0;

    private void Start()
    {
        gm = GameManager.Instance;

        slider.DOValue(1, 60f / gm.Bpm1).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);

    }

    

    // Update is called once per frame
    void Update()
    {
        
        //공격키를 눌렀으며 slider가 0.3보다 크고 0.7보다 작을 때 빨간 색
        if (im.attack && slider.normalizedValue > 0.3f && slider.normalizedValue < 0.7f)
        {
            slider.handleRect.GetComponent<Image>().color = Color.red;
        }
        else
        {
            slider.handleRect.GetComponent<Image>().color = Color.white;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageEnd : MonoBehaviour
{
    [SerializeField] private SceneChanger sc;
    [SerializeField] private AudioSource bgm;
    float bgmlength;
    void Start()
    {
        bgmlength = bgm.clip.length;
    }
    void Update()
    {
        //Debug.Log(bgmlength);
        if(Time.timeScale != 0)
            bgmlength -= Time.unscaledDeltaTime;
        if (bgmlength <= 0)
            sc.ChangeScene();

    }
}

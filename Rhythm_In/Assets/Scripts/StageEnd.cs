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
        Debug.Log(Time.realtimeSinceStartup);
        if (Time.realtimeSinceStartup >= bgmlength)
            sc.ChangeScene();

    }
}

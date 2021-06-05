using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageEnd : MonoBehaviour
{
    [SerializeField] private SceneChanger sc;
    [SerializeField] private AudioSource bgm;
    float a;
    void Start()
    {
        a = bgm.clip.length;
    }
    void Update()
    {
        Debug.Log(Time.realtimeSinceStartup);
        if (Time.realtimeSinceStartup >= a)
            sc.ChangeScene("Event02");

    }
}

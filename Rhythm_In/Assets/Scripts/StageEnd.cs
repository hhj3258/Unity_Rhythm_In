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
        Debug.Log("브금 길이: " + bgmlength);
    }
    void Update()
    {
        bgmlength -= Time.deltaTime;

        if (bgmlength <= 0)
            sc.ChangeScene();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;
    [SerializeField]
    private string useKey;
    void Update()
    {
        // 씬 전환시 전환될 씬이랑 사용할 키 설정
        if (Input.GetKeyDown(useKey))
        {
            Application.LoadLevel(nextSceneName);
        }
    }
}

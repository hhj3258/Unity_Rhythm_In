using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    private void Update()
    {
        // 로고에서 아무키나 눌러서 메인화면 가기
        if(SceneManager.GetActiveScene().name == "Logo")
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("MainMenu");
            }
        if (SceneManager.GetActiveScene().name == "MainMenu")
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Logo");
            }
    }
}



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
        LoadingSceneController.LoadingInstance.LoadScene(sceneName);
    }

    public void CheckButtonClick()
    {
        Debug.Log("확인");
    }
    public void Exit()
    {
            Application.Quit();
    }
}



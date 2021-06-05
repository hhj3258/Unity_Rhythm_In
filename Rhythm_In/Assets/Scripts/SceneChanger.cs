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

    public void isButtonClick()
    {
        Debug.Log("버튼 눌러짐");
    }
    public void Exit()
    {
            Application.Quit();
    }
}



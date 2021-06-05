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
    //Overloading ChangeScene
    public void ChangeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    public void Exit()
    {
        if (Application.isEditor)
            UnityEditor.EditorApplication.isPlaying = false;
        else
            Application.Quit();
    }
}



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
    void Start()
    {
    }
    void Update()
    {
      
    }
        public void Event01()
    {
        Application.LoadLevel("Event01");
    }
}



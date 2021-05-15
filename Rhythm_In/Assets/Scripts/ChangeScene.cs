using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void Stage01()
    {
        SceneManager.LoadScene("Stage01");
    }

    public void Event01()
    {
        SceneManager.LoadScene("Event01");
    }

}

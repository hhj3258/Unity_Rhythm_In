using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{

    [HideInInspector] public bool jump;    //Space
    [HideInInspector] public bool attack;
    [HideInInspector] public bool pause;


    void Update()
    {
        jump = Input.GetKeyDown(KeyCode.Space);
        attack = Input.GetKeyDown(KeyCode.A);
        pause = Input.GetKeyDown(KeyCode.Escape);


        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

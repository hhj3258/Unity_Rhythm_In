using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public InputManager im;

    public GameObject[] spriteA;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            spriteA[0].SetActive(false);
            spriteA[1].SetActive(true);
        }
        else
        {
            spriteA[0].SetActive(true);
            spriteA[1].SetActive(false);
        }
    }
}

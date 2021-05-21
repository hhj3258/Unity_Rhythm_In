using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIMove : MonoBehaviour
{
    public RectTransform pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("return")) {
            goLogo();
        }
        if (Input.GetKeyDown("escape"))
        {
            goMain();
        }
    }

    void goLogo()
    {
        pos.anchoredPosition = new Vector2(0, -10f);
    }
    void goMain()
    {
        pos.anchoredPosition = new Vector2(0, 0f);
    }

    public void goOption()
    {
        pos.anchoredPosition = new Vector2(18f, -10f);
    }
}

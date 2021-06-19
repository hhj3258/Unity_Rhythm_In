using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LogoManager : MonoBehaviour
{
    [SerializeField] private Sprite[] logoSprites;
    [SerializeField] private GameObject Logo;
    [SerializeField] private GameObject text;
    [SerializeField] private float alphaSpeed;
    [SerializeField] private GameObject button;

    private int random;
    SpriteRenderer ren;
    TextMeshProUGUI txt;
    Color color;
    float textAlpha;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        ren = Logo.GetComponent<SpriteRenderer>();
        txt = text.GetComponent<TextMeshProUGUI>();
        random = Random.Range(0, 2);
        ren.color = new Color(1, 1, 1, 0);
        switch (random)
        {
            case 0:
                Logo.transform.GetComponent<SpriteRenderer>().sprite = logoSprites[0];
                break;
            case 1:
                Logo.transform.GetComponent<SpriteRenderer>().sprite = logoSprites[1];
                break;
        }
    }
    void Update()
    {
        if(Time.realtimeSinceStartup>=3f)
            LogoManage();    
    }
    // Update is called once per frame
    void LogoManage()
    {
        Logo.SetActive(true);
        if (ren.color.a >= 0.93f)
            ren.color = new Color(1, 1, 1, 1);
        ren.color = new Color(1, 1, 1, Mathf.Lerp(ren.color.a, 1, 0.6f*Time.deltaTime));
        if (ren.color.a >= 0.7f)
        {
            if (txt.color.a >= 0.93f)
                txt.color = new Color(1, 1, 1, 1);
            txt.color= new Color(1,1,1, Mathf.Lerp(txt.color.a, 1, 0.6f * Time.deltaTime));
        }
        if (txt.color.a >= 0.7f)
        {
            button.SetActive(true);
        }

    }
}

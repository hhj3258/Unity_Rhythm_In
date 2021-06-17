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
        Debug.Log(ren.color.a);
        ren.color = new Color(1, 1, 1, Mathf.Lerp(ren.color.a, 1, 0.01f));
        if (ren.color.a >= 0.7f)
        {
            txt.color= new Color(1,1,1, Mathf.Lerp(txt.color.a, 1, 0.01f));
        }
        if (txt.color.a >= 0.9f)
        {
            button.SetActive(true);
        }

    }
}

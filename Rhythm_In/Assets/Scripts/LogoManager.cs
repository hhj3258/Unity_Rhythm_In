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
        ren = Logo.GetComponent<SpriteRenderer>();
        txt = text.GetComponent<TextMeshProUGUI>();
        color.a = 0;
        textAlpha = 0;
        random = Random.Range(0, 2);
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

    // Update is called once per frame
    void Update()
    {
        color = new Color(1, 1, 1, color.a + alphaSpeed * Time.deltaTime);
        ren.color = color;
        if (color.a >= 1 && txt.color.a <= 1)
        {
            txt.color= new Color(1,1,1, txt.color.a + alphaSpeed * Time.deltaTime);
            Debug.Log(txt.color.a);
        }
        if (txt.color.a >= 0.9f)
        {
            button.SetActive(true);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowImage : MonoBehaviour
{
    [SerializeField] private Sprite[] Openings;
    [SerializeField] private GameObject img;
    [SerializeField] SceneChanger sc;
    [SerializeField] private GameObject fade;
    [SerializeField] private float cutSceneTime;

    CanvasRenderer rdr;
    Image image;
    float time;

    bool isFade;
    bool isRunning;
    int picNum;
    
    // Start is called before the first frame update
    void Start()
    {
        image = img.GetComponent<Image>();
        picNum = 0;
        rdr = fade.GetComponent<CanvasRenderer>();
        isFade = true;
        isRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Fade();

            showImage();

        if (time > cutSceneTime)
        {
            isFade = false;
            if (rdr.GetColor().a > 0.95f)
            {
                time = 0;
                picNum++;
                if(picNum<Openings.Length)
                    isFade = true;
            }
        }
    }

    void showImage()
    {
        if (picNum < Openings.Length)
        {
            image.sprite = Openings[picNum];
        }
        else if (isRunning)
        {
            sc.ChangeScene();
            isRunning = false;
        }
    }


    void Fade() // true = 밝아지기, false = 어두워지기
    {
        if (isFade)
        {
            rdr.SetColor(new Color(1, 1, 1, Mathf.Lerp(rdr.GetColor().a, 0, 0.4f * Time.deltaTime)));
        }
        else 
            rdr.SetColor(new Color(1, 1, 1, Mathf.Lerp(rdr.GetColor().a, 1, 0.8f * Time.deltaTime)));
    }
}

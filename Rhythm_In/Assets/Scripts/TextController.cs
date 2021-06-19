using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextController : MonoBehaviour
{
    public GameObject fadeInImage; // 스크립트 실행 시 페이드 인 효과에 사용할 이미지
    public TextMeshProUGUI txt;
    public InputManager im;


    [SerializeField] private string[] texts; // 이벤트 씬에서 보여줄 텍스트 내용(대화, 독백 등)
    CanvasRenderer rdr;
    Color color;

    void Start()
    {
        rdr = fadeInImage.GetComponent<CanvasRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        FadeIn();
        showtext();
    }

    void showtext()
    {
        if (ShowText.IsInterect())
        {
            txt.text = texts[ShowText.TextNum()];
        }
        else
            txt.text = texts[texts.Length - 1];
    }

    void FadeIn()
    {
        color = rdr.GetColor();
        // 페이드인 효과 -> 알파 값이 1~0.3f일때는 느리게, 0.3f~0.01f일때는 빠르게 페이드 인
        // 알파값이 0.01이하일때는 해야하는 연산을 줄이기 위해 알파값을 0으로 고정
        if (color.a <= 0.3f && color.a > 0.1f)
        {
            rdr.SetColor(new Color(1, 1, 1, Mathf.Lerp(color.a, 0, 0.7f * Time.deltaTime)));
        }
        else if (color.a <= 0.01f)
            rdr.SetColor(new Color(1, 1, 1, 0));
        else
            rdr.SetColor(new Color(1, 1, 1, Mathf.Lerp(color.a, 0, 0.4f * Time.deltaTime)));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StageEnd : MonoBehaviour
{
    [SerializeField] private SceneChanger sc;
    [SerializeField] private AudioSource bgm;
    [SerializeField] private GameObject ScoreUI;
    //[SerializeField] private GameObject Btn;
    float bgmlength;

    TextMeshProUGUI txt;

    private GameManager gm;
    private string strRank;
    public GameObject grade;
    void Start()
    {
        gm = GameManager.Instance;
        bgmlength = bgm.clip.length;
        Debug.Log("브금 길이: " + bgmlength);
    }
    void Update()
    {
        bgmlength -= Time.deltaTime;
            if (bgmlength <= 0)
        {
            ScoreRank();
            //txt.text = "Grade : "+; // 여기에 점수 스크립트
            ScoreUI.SetActive(true);
            bgm.volume = Mathf.Lerp(bgm.volume, 0, 0.01f);
            Time.timeScale = Mathf.Lerp(Time.timeScale, 0, 0.1f);
            //Btn.SetActive(true);
            grade.GetComponent<TextMeshPro>().text = "Grade : "+strRank;
        }
    }

    void ScoreRank()
    {
        if (gm.score > 20000)
        {
            strRank = "S+";
        }
        else if (gm.score > 19000)
        {
            strRank = "S";
        }
        else if (gm.score > 18000)
        {
            strRank = "A+";
        }
        else if (gm.score > 16000)
        {
            strRank = "A";
        }
        else if (gm.score > 14000)
        {
            strRank = "B+";
        }
        else if (gm.score > 12000)
        {
            strRank = "B";
        }
        else if (gm.score > 10000)
        {
            strRank = "C";
        }
        else if (gm.score > 8000)
        {
            strRank = "D";
        }
        else
        {
            strRank = "F";
        }
    }
}

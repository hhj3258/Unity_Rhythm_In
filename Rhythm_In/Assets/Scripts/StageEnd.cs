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
    [SerializeField] private GameObject Btn;
    float bgmlength;

    TextMeshProUGUI txt;

    void Start()
    {
        bgmlength = bgm.clip.length;
        Debug.Log("��� ����: " + bgmlength);
    }
    void Update()
    {
        bgmlength -= Time.deltaTime;
            if (bgmlength <= 0)
        {
            //txt.text = "Grade : "; // ���⿡ ���� ��ũ��Ʈ
            ScoreUI.SetActive(true);
            bgm.volume = Mathf.Lerp(bgm.volume, 0, 0.01f);
            Time.timeScale = Mathf.Lerp(Time.timeScale, 0, 0.1f);
            Btn.SetActive(true);
            GameObject.Find("Grade").GetComponent<TextMeshPro>().text = "Grade : ��";
        }
        //sc.ChangeScene();

    }
}

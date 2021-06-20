using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class HitboxChecker : MonoBehaviour
{
    //플레이어 자식 오브젝트 Hitbox에 달아줄 클래스
    //공격 로직 판정에 필요한 콜라이더 trigger 정보를 PlayerMove에 전달함.
    private bool isEnemy = false;
    private Collider2D hitCol;
    public static int judge = -1;
    public TextMeshProUGUI txtTest;

    public GameObject[] imgJudge;
    public InputManager im;

    public bool IsEnemy
    {
        get { return isEnemy; }
        set { isEnemy = value; }
    }

    public Collider2D HitCol
    {
        get { return hitCol; }

    }
    
    public bool IsPerfect
    {
        get { return IsPerfect; }
    }

    private int temp = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(isEnemy);
        if (other.transform.CompareTag("Enemy"))
        {
            isEnemy = true;
            hitCol = other;
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.name.Equals("SearchBox"))
        {
            Debug.Log(other.name);

            if (Mathf.Abs(other.transform.position.x - transform.position.x) <= 0.6f)
            {
                //Debug.Log(other.transform.position.x - transform.position.x);
                judge = 0;
                if (im.attack)
                {
                    imgJudge[0].SetActive(true);
                    imgJudge[0].transform.DOScale(1.5f, 0.2f).SetEase(Ease.OutBack).SetLoops(2, LoopType.Yoyo);
                    Invoke("OffJudge", 0.5f);
                }

            }
            else
            {
                judge = 2;
                if (im.attack)
                {

                    imgJudge[1].SetActive(true);
                    imgJudge[1].transform.DOScale(1.5f, 0.2f).SetEase(Ease.OutBack).SetLoops(2, LoopType.Yoyo);
                    Invoke("OffJudge", 0.5f);
                }

                //txtTest.text = "bad";
            }
        }

    }

    void OffJudge()
    {
        for(int i=0;i<imgJudge.Length;i++)
            imgJudge[i].SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isEnemy = false;
    }

}

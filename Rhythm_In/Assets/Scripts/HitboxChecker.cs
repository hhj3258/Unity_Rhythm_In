using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitboxChecker : MonoBehaviour
{
    //플레이어 자식 오브젝트 Hitbox에 달아줄 클래스
    //공격 로직 판정에 필요한 콜라이더 trigger 정보를 PlayerMove에 전달함.
    private bool isEnemy = false;
    private Collider2D hitCol;

    private bool isPerfect=false;

    public TextMeshProUGUI txtTest;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(isEnemy);
        if (other.transform.CompareTag("Enemy"))
        {
            isEnemy = true;
            hitCol = other;
            Debug.Log(hitCol.name);
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (Mathf.Abs(other.transform.position.x - transform.position.x) <= 0.5f)
        {
            //Debug.Log(other.transform.position.x - transform.position.x);
            isPerfect = true;
            txtTest.text = "Perfect!";
        }
        else
        {
            isPerfect = false;
            txtTest.text = "";
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        isEnemy = false;
    }

    private void Update()
    {

    }
}

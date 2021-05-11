using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxChecker : MonoBehaviour
{
    //플레이어 자식 오브젝트 Hitbox에 달아줄 클래스
    //공격 로직 판정에 필요한 콜라이더 trigger 정보를 PlayerMove에 전달함.

    private bool isEnemy = false;
    private Collider2D hitCol;
    public bool IsEnemy
    {
        get { return isEnemy; }
        set { isEnemy = value; }
    }

    public Collider2D HitCol
    {
        get { return hitCol; }
        set { hitCol = value; }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(isEnemy);
        if (other.transform.CompareTag("Enemy"))
        {
            isEnemy = true;
            hitCol = other;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isEnemy = false;
    }
}

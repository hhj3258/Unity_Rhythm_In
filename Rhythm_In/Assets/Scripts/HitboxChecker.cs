using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxChecker : MonoBehaviour
{
    //�÷��̾� �ڽ� ������Ʈ Hitbox�� �޾��� Ŭ����
    //���� ���� ������ �ʿ��� �ݶ��̴� trigger ������ PlayerMove�� ������.

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

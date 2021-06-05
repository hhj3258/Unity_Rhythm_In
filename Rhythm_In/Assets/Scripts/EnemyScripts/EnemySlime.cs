using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class EnemySlime : EnemyController
{
    [SerializeField] private float moveSpeed;
    private int health = 2;

    private TextMeshProUGUI tests;
    private void Update()
    {
        //if (im.attack) Debug.Log("a");

        if (hitboxChecker.IsEnemy 
            && im.attack 
            && health > 0 
            && hitboxChecker.HitCol.transform == transform)
        {
            health -= 1;

            if (health == 0)
                Attacked();
            else
                BackMove();
        }
        
    }

    void BackMove()
    {
        transform.DOMoveX(transform.position.x + PlayerMove.MoveSpeed, 1f).SetEase(Ease.OutQuart);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.Health -= 10f;
    }


}

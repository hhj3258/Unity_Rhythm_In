using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemySlime : EnemyController
{
    [SerializeField] private float moveSpeed;


    private int health = 3;


    private void Update()
    {
        //if (im.attack) Debug.Log("a");

        if (hitboxChecker.IsEnemy && im.attack && health > 0 && hitboxChecker.HitCol.transform == transform)
        {
            health -= 1;

            if (health == 0)
            {
                Attacked();
            }
            else
            {
                BackMove();
            }

        }


    }

    void BackMove()
    {
        transform.DOMoveX(transform.position.x + 10f, 1f).SetEase(Ease.OutExpo);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.Health -= 10f;
    }


}

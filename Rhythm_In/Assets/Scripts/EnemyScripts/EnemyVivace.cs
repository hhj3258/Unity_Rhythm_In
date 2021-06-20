using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyVivace : EnemyController
{
    private bool isAttack;

    protected override void Start()
    {
        base.Start();
        health = 1;
        isAttack = false;
    }
    

    private void Update()
    {
        if (hitboxChecker.IsEnemy
            && im.attack
            && health > 0
            && hitboxChecker.HitCol.transform == transform)
        {
            health -= 1;
            //Debug.Log("∫ÒπŸ√º");
            if (health == 0)
            {
                Attacked();
                mainCam.CameraAttackMove();
            }

            JudgeMent(70);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name.Equals("Player") && !isAttack)
        {
            RunAttack();
            isAttack = true;
        }
    }

    void RunAttack()
    {
        transform.GetComponent<Animator>().SetTrigger("doAttack");

        transform.DOMoveX(transform.position.x-7, 1).SetEase(Ease.InOutQuad);
    }

}

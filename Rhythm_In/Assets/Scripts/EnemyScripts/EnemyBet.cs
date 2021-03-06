using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class EnemyBet : EnemyController
{
    private bool isAttack;
    [SerializeField] private GameObject fireBall;

    protected override void Start()
    {
        base.Start();
        health = 1;
        isAttack = false;
    }

    private void Update()
    {
        if (hitboxChecker.IsEnemy && im.attack && health > 0)
        {
            if(hitboxChecker.HitCol.transform == transform)
            {
                health -= 1;

                if (health == 0)
                {
                    Attacked();
                    //Debug.Log("chk");
                }

                fireBall.transform.GetComponent<Animator>().SetTrigger("doAttach");

                JudgeMent(80);
            }

            if(hitboxChecker.HitCol.transform == transform.GetChild(0))
            {
                Parrying();
                mainCam.CameraAttackMove();

                JudgeMent(80);
            }

        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name.Equals("Player") && !isAttack)
        {
            Attack();
            isAttack = true;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name.Equals("FireBall") && isAttack)
        {
            health -= 1;
            if (health == 0)
            {
                Attacked();
            }

            fireBall.transform.GetComponent<Animator>().SetTrigger("doAttach");
        }
    }

    private void Attack()
    {
        transform.GetComponent<Animator>().SetTrigger("doAttack");
        fireBall.transform.GetComponent<Animator>().SetTrigger("doAttack");
        fireBall.transform.DOMove(new Vector3(transform.position.x - 10, 2.5f, transform.position.z), 0.7f);
    }

    private void Parrying()
    {
        enemySound.Play();
        fireBall.GetComponent<SpriteRenderer>().flipX = false;
        fireBall.transform.DOMove(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), 0.5f);
    }
}

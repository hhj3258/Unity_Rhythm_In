using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class EnemySlime : EnemyController
{

    protected override void Start()
    {
        base.Start();
        health = 2;
    }

    private void Update()
    {
        if (hitboxChecker.IsEnemy 
            && im.attack 
            && health > 0 
            && hitboxChecker.HitCol.transform == transform)
        {
            health -= 1;

            if (health == 0)
            {
                Attacked();
                mainCam.CameraAttackMove();
            }
            else
            {
                BackMove();
                mainCam.CameraAttackMove();
            }
                

            
        }
        
    }

    void BackMove()
    {
        transform.DOMoveX(transform.position.x + 
            (PlayerMove.MoveSpeed * 60f/gm.Bpm1), 60f / gm.Bpm1).SetEase(Ease.OutQuart);
        enemySound.Play();
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    GameManager.Instance.Health -= 1f;
    //}


}

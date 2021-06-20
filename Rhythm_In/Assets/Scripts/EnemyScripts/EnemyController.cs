using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour
{
    protected GameObject player;
    protected HitboxChecker hitboxChecker;
    protected InputManager im;
    protected GameManager gm;

    public AudioSource enemySound;
    protected int health=0;

    protected CameraMove mainCam;

    protected GameObject txtJudge;

    protected virtual void Start()
    {
        txtJudge = GameObject.Find("txtJudge");
        player = GameObject.FindGameObjectWithTag("Player");
        hitboxChecker = player.GetComponentInChildren<HitboxChecker>();
        im = player.GetComponent<InputManager>();
        gm = GameManager.Instance;
        mainCam = FindObjectOfType<CameraMove>();
    }

    // 공격 로직 수정
    // 기존 레이에서 콜라이더 충돌 방식으로 변경함
    public void Attacked()
    {
        transform.GetComponent<Animator>().SetTrigger("doHitDie");
        transform.GetComponent<CircleCollider2D>().enabled = false;

        enemySound.Play();

        StartCoroutine(OnDestroyEnemy());

        
    }

    IEnumerator OnDestroyEnemy()
    {
        yield return new WaitForSeconds(1);
        Destroy(transform.gameObject);
    }

    public void JudgeMent(int myScore)
    {
        if (HitboxChecker.judge == 0)
        {
            txtJudge.GetComponent<TextMeshProUGUI>().text = "Perfect";

            gm.score += myScore+50;
        }
        //else if (HitboxChecker.judge == 1)
        //{
        //    txtJudge.GetComponent<TextMeshProUGUI>().text = "Good";
        //}
        else
        {
            txtJudge.GetComponent<TextMeshProUGUI>().text = "Bad";
            gm.score += myScore;
        }
    }
}

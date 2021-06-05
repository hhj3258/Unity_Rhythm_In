using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;

    protected HitboxChecker hitboxChecker;
    protected InputManager im;

    private GameManager gm;

    private void Start()
    {
        gm = GameManager.Instance;
        player = gm.Player;
        hitboxChecker = player.GetComponentInChildren<HitboxChecker>();
        im = player.GetComponent<InputManager>();
    }

    private void Update()
    {
        if (!player) gm.Player = GameObject.FindGameObjectWithTag("Player");

    }

    // 공격 로직 수정
    // 기존 레이에서 콜라이더 충돌 방식으로 변경함
    public void Attacked()
    {
        transform.GetComponent<Animator>().SetTrigger("doHitDie");
        transform.GetComponent<CircleCollider2D>().enabled = false;
        StartCoroutine(OnDestroyEnemy());
    }

    IEnumerator OnDestroyEnemy()
    {
        yield return new WaitForSeconds(1);
        Destroy(transform.gameObject);
    }
}

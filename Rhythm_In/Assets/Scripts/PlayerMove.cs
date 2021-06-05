using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpPower;
    [SerializeField] private float hitbox;




    Rigidbody2D rigid;
    SpriteRenderer spRenderer;
    Animator anim;

    //애니메이션 변수 id
    private static readonly int IsJumping = Animator.StringToHash("isJumping");
    private static readonly int IsRun = Animator.StringToHash("isRun");

    int damDirc = 0;
    [SerializeField] float maxSlow;
    [SerializeField] float slowInterval;

    public InputManager im;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    private float nowTime=0;
    private int tempTime = 0;
    private int isDoubleJump = 0;   //더블 점프 카운터
    void Update()
    {
        anim.SetBool(IsRun, true);

        nowTime += Time.deltaTime;

        if((int)nowTime > tempTime)
        {
            tempTime = (int)nowTime;
            Debug.Log("noTime: " + tempTime);
            Debug.Log("pos: " + transform.position);
            

        }
        

        //공격
        if (im.attack)
        {
            


            anim.SetTrigger("doAttack1");

            //if (HitboxChecker.IsEnemy)
            //{
            //    Attack(HitboxChecker.HitCol);
            //}
                

        }

        if ((int)Time.timeSinceLevelLoad > temp)
        {
            temp = (int)Time.timeSinceLevelLoad;
            //StartCoroutine(PlayerPos());
            //Debug.Log((int)Time.timeSinceLevelLoad + "초" + transform.position);
        }


        transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        //rigid.velocity = new Vector2(moveSpeed * Time.fixedDeltaTime, 0);
    }
    int temp = 0;



    

    private void FixedUpdate()
    {

        //점프 & 더블 점프
        if (im.jump && isDoubleJump < 2)
        {

            if (isDoubleJump == 1)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, 0f);
                rigid.AddForce(Vector2.up * (jumpPower * 1.2f), ForceMode2D.Impulse);
            }
            else
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

            anim.SetBool(IsJumping, true);

            isDoubleJump++;
        }
    }





    private void OnCollisionEnter2D(Collision2D other)
    {
        //바닥 착지시 점프 애니메이션 중지
        if (other.transform.CompareTag("Ground"))
            anim.SetBool(IsJumping, false);
        //더블 점프 카운트 초기화
        isDoubleJump = 0;

        if (other.transform.CompareTag("Enemy"))
        {
            //OnDamaged(other.transform.position);
        }

    }

    //슬로우모션 로직 콜라이더 trigger 방식으로 변경
    private void OnTriggerEnter2D(Collider2D other)
    {
        //OnSlowbox(other);
    }


    //슬로우모션 판정
    void OnSlowbox(Collider2D other)
    {

        if (other.transform.CompareTag("Enemy"))
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, maxSlow, slowInterval * Time.deltaTime);
            Debug.Log(Time.timeScale);
        }
        else
            Time.timeScale = 1f;
    }

    //적에게 부딪혔을 때
    void OnDamaged(Vector2 targetPos)
    {


        //6=PlayerDamaged
        gameObject.layer = 6;

        //무적 상태일 때 티가 나도록 알파 값을 낮춰줌
        spRenderer.color = new Color(1, 1, 1, 0.7f);



        //플레이어 포지션과 enemy 포지션의 차를 이용해서 플레이어가 튕겨져 나갈 방향 계산
        if ((transform.position.x - targetPos.x) > 0) damDirc = -1;
        else damDirc = -1;

        //위 계산으로 나온 방향으로 플레이어에게 힘을 가함
        rigid.AddForce(new Vector2(damDirc, 0f) * 40f, ForceMode2D.Impulse);

        anim.SetTrigger("doDamaged");

        //1초간 무적상태
        Invoke("OffDamaged", 1f);
    }

    //무적 판정
    void OffDamaged()
    {
        gameObject.layer = 0;
        spRenderer.color = new Color(1, 1, 1, 1);
    }
}

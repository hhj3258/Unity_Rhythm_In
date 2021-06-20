using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private static float moveSpeed = 15f;
    [SerializeField] private float jumpPower;
    [SerializeField] private float hitbox;
    [SerializeField] private float maxSlow;
    [SerializeField] private float slowInterval;
    [SerializeField] private float attackDelay;


    private int isDoubleJump = 0;   //더블 점프 카운터
    private static bool gameOver;
    private float attackDelayedTime = 0;

    public AudioSource swordSound;
    public InputManager im;
    public Image[] imgHealths;
    public GameObject gameoverImage; // 게임오버 이미지
    public GameObject btn; // 버튼


    AudioSource bgm;

    Rigidbody2D rigid;
    SpriteRenderer spRenderer;
    Animator anim;
    SpriteRenderer spGO;


    //애니메이션 변수 id
    private static readonly int IsJumping = Animator.StringToHash("isJumping");
    private static readonly int IsRun = Animator.StringToHash("isRun");

 


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        bgm = GameObject.Find("Fast and Run").GetComponent<AudioSource>();
        gameOver = false;
        spGO = gameoverImage.GetComponent<SpriteRenderer>();
    }
    public static float MoveSpeed
    {
        get { return moveSpeed; }
    }

    public static bool GameOver { 
        get { return gameOver; } 
    }

    private float nowTime = 0;
    private int tempTime = 0;

    void Update()
    {
        if (gameOver && moveSpeed != 0) // 게임오버 시 -> imageHealth 관련
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.DieAnim") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                Time.timeScale = Mathf.Lerp(Time.timeScale, 0, 0.04f); // timeScale 천천히 0으로
                GameObject.Find("Canvas").transform.Find("GameOver").gameObject.SetActive(true);
                bgm.volume = Mathf.Lerp(bgm.volume, 0, 0.01f); // bgm 천천히 0으로

                spGO.color = new Color(1, 1, 1, Mathf.Lerp(spGO.color.a, 1, 0.006f)); // 게임오버 이미지 출력 -> 알파 값 조정
                if (spGO.color.a >= 0.9)
                {
                    GameObject.Find("GameOver_Menu").GetComponent<SpriteRenderer>().color = 
                        new Color(1,1,1,Mathf.Lerp(GameObject.Find("GameOver_Menu").GetComponent<SpriteRenderer>().color.a,1,0.03f));
                    if (GameObject.Find("GameOver_Menu").GetComponent<SpriteRenderer>().color.a > 0.8f)
                    {
                        Time.timeScale = 0;
                        btn.SetActive(true); // 이미지 나타나면 버튼 활성화
                    }

                }

            }
            moveSpeed = Mathf.Lerp(moveSpeed, 0, 0.04f);
            

        }

        anim.SetBool(IsRun, true);

        nowTime += Time.deltaTime;

        if ((int)nowTime > tempTime)
        {
            tempTime = (int)nowTime;
           // Debug.Log("nowTime: " + (int)nowTime);
            //Debug.Log("pos: " + transform.position);
        }

        //공격
        if (im.attack && Time.realtimeSinceStartup - attackDelayedTime >= attackDelay)
        {
            attackDelayedTime = Time.realtimeSinceStartup;
            anim.SetTrigger("doAttack1");
            swordSound.Play();
        }

        transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);

        //플레이어 좌표와 시간간 보정
        if (transform.position.x < nowTime * 15)
        {
            moveSpeed = moveSpeed * 1.01f;
        }
        else
        {
            moveSpeed = 15;
        }

        //점프 & 더블 점프
        if (im.jump && isDoubleJump < 2)
        {

            if (isDoubleJump == 1)  //더블점프
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
        {
            //Debug.Log("착지");
            anim.SetBool(IsJumping, false);

            //더블 점프 카운트 초기화
            isDoubleJump = 0;
        }

        if (other.transform.CompareTag("Enemy"))
        {
            OnDamaged(other.transform.position);
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
        //if ((transform.position.x - targetPos.x) > 0) damDirc = -1;
        //else damDirc = -1;

        //위 계산으로 나온 방향으로 플레이어에게 힘을 가함
        //rigid.AddForce(new Vector2(damDirc, 0f) * 40f, ForceMode2D.Impulse);

        anim.SetTrigger("doDamaged");

        //1초간 무적상태
        Invoke("OffDamaged", 1f);

        for (int i = imgHealths.Length -1; i >= 0; i--)
        {
            if (imgHealths[i].fillAmount != 0)
            {
                if (imgHealths[i].fillAmount != 1)
                {
                    imgHealths[i].fillAmount = 0;
                }
                else
                {
                    imgHealths[i].fillAmount -= 0.47f;
                }

                if (imgHealths[0].fillAmount == 0)
                {
                    gameOver = true;
                    anim.SetTrigger("doDie");
                    Debug.Log("GameOver");
                }
                break;
            }
        }
    }

    //무적 판정
    void OffDamaged()
    {
        gameObject.layer = 0;
        spRenderer.color = new Color(1, 1, 1, 1);
    }
}

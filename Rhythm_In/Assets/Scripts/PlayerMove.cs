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


    private int isDoubleJump = 0;   //���� ���� ī����
    private static bool gameOver;
    private float attackDelayedTime = 0;

    public AudioSource swordSound;
    public InputManager im;
    public Image[] imgHealths;
    public GameObject gameoverImage; // ���ӿ��� �̹���
    public GameObject btn; // ��ư


    AudioSource bgm;

    Rigidbody2D rigid;
    SpriteRenderer spRenderer;
    Animator anim;
    SpriteRenderer spGO;


    //�ִϸ��̼� ���� id
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
        if (gameOver && moveSpeed != 0) // ���ӿ��� �� -> imageHealth ����
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.DieAnim") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                Time.timeScale = Mathf.Lerp(Time.timeScale, 0, 0.04f); // timeScale õõ�� 0����
                GameObject.Find("Canvas").transform.Find("GameOver").gameObject.SetActive(true);
                bgm.volume = Mathf.Lerp(bgm.volume, 0, 0.01f); // bgm õõ�� 0����

                spGO.color = new Color(1, 1, 1, Mathf.Lerp(spGO.color.a, 1, 0.006f)); // ���ӿ��� �̹��� ��� -> ���� �� ����
                if (spGO.color.a >= 0.9)
                {
                    GameObject.Find("GameOver_Menu").GetComponent<SpriteRenderer>().color = 
                        new Color(1,1,1,Mathf.Lerp(GameObject.Find("GameOver_Menu").GetComponent<SpriteRenderer>().color.a,1,0.03f));
                    if (GameObject.Find("GameOver_Menu").GetComponent<SpriteRenderer>().color.a > 0.8f)
                    {
                        Time.timeScale = 0;
                        btn.SetActive(true); // �̹��� ��Ÿ���� ��ư Ȱ��ȭ
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

        //����
        if (im.attack && Time.realtimeSinceStartup - attackDelayedTime >= attackDelay)
        {
            attackDelayedTime = Time.realtimeSinceStartup;
            anim.SetTrigger("doAttack1");
            swordSound.Play();
        }

        transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);

        //�÷��̾� ��ǥ�� �ð��� ����
        if (transform.position.x < nowTime * 15)
        {
            moveSpeed = moveSpeed * 1.01f;
        }
        else
        {
            moveSpeed = 15;
        }

        //���� & ���� ����
        if (im.jump && isDoubleJump < 2)
        {

            if (isDoubleJump == 1)  //��������
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
        //�ٴ� ������ ���� �ִϸ��̼� ����
        if (other.transform.CompareTag("Ground"))
        {
            //Debug.Log("����");
            anim.SetBool(IsJumping, false);

            //���� ���� ī��Ʈ �ʱ�ȭ
            isDoubleJump = 0;
        }

        if (other.transform.CompareTag("Enemy"))
        {
            OnDamaged(other.transform.position);
        }

    }

    //���ο��� ���� �ݶ��̴� trigger ������� ����
    private void OnTriggerEnter2D(Collider2D other)
    {
        //OnSlowbox(other);
    }


    //���ο��� ����
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

    //������ �ε����� ��
    void OnDamaged(Vector2 targetPos)
    {
        //6=PlayerDamaged
        gameObject.layer = 6;

        //���� ������ �� Ƽ�� ������ ���� ���� ������
        spRenderer.color = new Color(1, 1, 1, 0.7f);

        //�÷��̾� �����ǰ� enemy �������� ���� �̿��ؼ� �÷��̾ ƨ���� ���� ���� ���
        //if ((transform.position.x - targetPos.x) > 0) damDirc = -1;
        //else damDirc = -1;

        //�� ������� ���� �������� �÷��̾�� ���� ����
        //rigid.AddForce(new Vector2(damDirc, 0f) * 40f, ForceMode2D.Impulse);

        anim.SetTrigger("doDamaged");

        //1�ʰ� ��������
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

    //���� ����
    void OffDamaged()
    {
        gameObject.layer = 0;
        spRenderer.color = new Color(1, 1, 1, 1);
    }
}

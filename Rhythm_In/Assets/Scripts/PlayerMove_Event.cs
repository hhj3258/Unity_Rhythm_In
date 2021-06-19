using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove_Event : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float attackDelay;
    [SerializeField] private GameObject[] Slime; // slime[0] = 본체, slime[1] = 느낌표
    private SpriteRenderer sRenderer;
    Rigidbody2D rigid;
    Animator anim;
    public InputManager im;
    Vector3 moveVelocity;
    private bool isMoving;
    public AudioSource swordSound;
    private float attackDelayedTime;
    float eventTime;

    public bool getisMoving
    {
        get { return isMoving; }
    }

    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        sRenderer = gameObject.GetComponent<SpriteRenderer>();

        isMoving = false;

        eventTime = 0;
    }
    private void Update()
    {
        if (transform.position.x <= 60)
        {
            Attack();
            Move();
        }
        else
        {
            SceneChangeEvent();
        }

    }

    void SceneChangeEvent() // 슬라임이 플레이어 발견하는 이벤트
    {
        Slime[0].GetComponent<SpriteRenderer>().flipX = false;
        Slime[1].SetActive(true);
        Debug.Log("eventTime : "+ eventTime);
        anim.SetBool("isRun", false);
        isMoving = false;
        eventTime += Time.deltaTime;
        if (eventTime >= 3.5f && eventTime <= 8f) // 슬라임이 도망
        {
            Slime[1].SetActive(false);
            Slime[0].GetComponent<SpriteRenderer>().flipX = true;
            Slime[0].transform.position = new Vector3(Mathf.Lerp(Slime[0].transform.position.x, 
                Slime[0].transform.position.x + 1, 2f * Time.deltaTime), Slime[0].transform.position.y, 0);
        }
        else if (eventTime >= 8f) // 플레이어 추격
        {
            isMoving = true;
            Slime[0].SetActive(false);
            anim.SetBool("isRun", true);
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, transform.position.x + 1, 15f * Time.deltaTime), transform.position.y, 0);

        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Wall")
            isMoving = false;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall")
            isMoving = false;
        if (col.gameObject.tag == "Ground")
            isMoving = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SceneChanger")
        {
            LoadingSceneController.LoadingInstance.LoadScene("Stage01");
        }
    }

    void Move()
    {
        moveVelocity = Vector3.zero;
        anim.SetBool("isRun", false);
        if (im.left)
        {
            moveVelocity = Vector3.left;
            anim.SetBool("isRun", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (im.right)
        {
            moveVelocity = Vector3.right;
            anim.SetBool("isRun", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        transform.position += moveVelocity * moveSpeed * Time.deltaTime;
    }

    void Attack()
    {
        if (im.attack && Time.realtimeSinceStartup - attackDelayedTime >= attackDelay)
        {
            attackDelayedTime = Time.realtimeSinceStartup;
            anim.SetTrigger("doAttack1");
            swordSound.Play();
        }
    }
}

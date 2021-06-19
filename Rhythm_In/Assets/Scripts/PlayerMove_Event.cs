using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove_Event : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float attackDelay;
    private SpriteRenderer sRenderer;
    Rigidbody2D rigid;
    Animator anim;
    public InputManager im;
    Vector3 moveVelocity;
    private bool isMoving;
    public AudioSource swordSound;
    private float attackDelayedTime;

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
    }
    private void Update()
    {
        if (im.attack && Time.realtimeSinceStartup - attackDelayedTime >= attackDelay)
        {
            attackDelayedTime = Time.realtimeSinceStartup;
            anim.SetTrigger("doAttack1");
            swordSound.Play();
        }
    }
    void FixedUpdate()
    {
        Move();
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
    }
}

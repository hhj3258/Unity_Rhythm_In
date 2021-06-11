using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove_Event : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10f;
    private SpriteRenderer sRenderer;
    Rigidbody2D rigid;
    Animator anim;
    public InputManager im;
    Vector3 moveVelocity;
    private bool isMoving;

    //애니메이션 변수 id
    private static readonly int IsRun = Animator.StringToHash("isRun");

    public bool getisMoving
    {
        get { return isMoving; }
    }

    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        sRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Wall")
            isMoving = false;
        else if (col.gameObject.tag == "Ground")
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
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove_Event : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpPower = 10f;
    private SpriteRenderer sRenderer;
    Rigidbody2D rigid;
    Animator anim;
    
    //애니메이션 변수 id
    private static readonly int IsJumping = Animator.StringToHash("isJumping");
    private static readonly int IsRun = Animator.StringToHash("isRun");

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

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            anim.SetBool("isRun", false);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
            anim.SetBool("isRun", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
            anim.SetBool("isRun", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        transform.position += moveVelocity * moveSpeed * Time.deltaTime;
    }
    
    
    
    
}

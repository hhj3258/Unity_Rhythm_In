using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float jumpPower;
    Rigidbody2D rigid;
    SpriteRenderer spRenderer;
    Animator anim;
    private static readonly int IsJumping = Animator.StringToHash("isJumping");

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //Jump
        if (Input.GetButton("Jump"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool(IsJumping, true);
        }
        
        //방향키에서 손을 떼면 극적으로 스탑
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        if (Input.GetButton("Horizontal"))
        {
            //flipX는 bool 변수, 왼쪽 방향키를 눌렀다면 flipX=true
            spRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        //달리기 애니메이션
        if(Mathf.Abs(rigid.velocity.x) < 0.6f)
        {
            anim.SetBool("isRun", false);
        }
        else
        {
            anim.SetBool("isRun", true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move Speed
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        
        //Max Speed
        if(rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < (maxSpeed * -1f) )
        {
            rigid.velocity = new Vector2((maxSpeed * -1f), rigid.velocity.y);
        }
        
        //Landing Platform
        Debug.DrawRay(rigid.position, Vector3.down, Color.green);

        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1);

        if (rayHit.collider != null)
        {
            Debug.Log(rayHit.collider.name);
        }
    }
}

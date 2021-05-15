using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpPower;
    [SerializeField] private float hitbox;
    public HitboxChecker HitboxChecker;
    
    
    
    Rigidbody2D rigid;
    SpriteRenderer spRenderer;
    Animator anim;
    
    //애니메이션 변수 id
    private static readonly int IsJumping = Animator.StringToHash("isJumping");
    private static readonly int IsRun = Animator.StringToHash("isRun");

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    //더블 점프 카운터
    private int isDoubleJump = 0;
    void Update()
    {

        //씬 리셋
        if (Input.GetKey(KeyCode.R))
            SceneManager.LoadScene("Stage01");

        if (Input.GetKey(KeyCode.A))
        {
            SceneManager.LoadScene(0);
        }
        
        //이동 애니메이션
        if (rigid.velocity.x < 1f)
            anim.SetBool(IsRun, false);
        else
            anim.SetBool(IsRun, true);

        

        
        //공격
        if(Input.GetKeyDown(KeyCode.X) || Input.GetMouseButtonDown(0) )
        {
            anim.SetTrigger("doAttack1");
            
            if(HitboxChecker.IsEnemy)
                Attack(HitboxChecker.HitCol);
            /*
            //플레이어 포지션 기준으로 X축 방향으로 RAY를 쏴줌, Enemy에게만 맞도록 layer 설정
            RaycastHit2D rayAttack = 
                Physics2D.Raycast(rigid.position, Vector2.right, hitbox, LayerMask.GetMask("Enemy"));
            
            Debug.DrawRay(rigid.position, Vector2.right * hitbox, new Color(1, 1, 1));
            
            //레이가 감지되면 맞은 오브젝트의 die 애니메이션 재생
            //콜라이더를 비활성화 시켜줌으로써 플레이어에게 피해 없음
            //애니메이션이 끝난 뒤(1초 뒤)에 오브젝트 삭제
            if (rayAttack)
            {
                //Debug.Log(raycastHit2D.transform.name);
                rayAttack.transform.GetComponent<Animator>().SetTrigger("doHitDie");
                rayAttack.collider.enabled = false;
                StartCoroutine(OnDestroyEnemy(rayAttack));
            }
            */
            
            //transform.GetChild(1).GetComponent<>()
        }
        
        
    }
    
    // 공격 로직 수정
    // 기존 레이에서 콜라이더 충돌 방식으로 변경함
    void Attack(Collider2D other)
    {
        
        //Debug.Log(raycastHit2D.transform.name);
        other.transform.GetComponent<Animator>().SetTrigger("doHitDie");
        other.enabled = false;
        StartCoroutine(OnDestroyEnemy(other));
    }
    

    private void FixedUpdate()
    {
        //이동
        rigid.AddForce(Vector2.right * moveSpeed );
        
        //점프 & 더블 점프
        if (Input.GetButtonDown("Jump") && isDoubleJump < 2)
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
    
    
    IEnumerator OnDestroyEnemy(Collider2D raycastHit2D)
    {
        yield return new WaitForSeconds(1);
        Destroy(raycastHit2D.transform.gameObject);
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        //바닥 착지시 점프 애니메이션 중지
        if(other.transform.CompareTag("Ground"))
            anim.SetBool(IsJumping, false);
        //더블 점프 카운트 초기화
        isDoubleJump = 0;

        if (other.transform.CompareTag("Enemy"))
        {
            OnDamaged(other.transform.position);
        }
        
    }

    //슬로우모션 로직 콜라이더 trigger 방식으로 변경
    private void OnTriggerEnter2D(Collider2D other)
    {
        OnSlowbox(other);
    }


    //슬로우모션 판정
    void OnSlowbox(Collider2D other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            Time.timeScale = 0.5f;
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

        
        int damDirc = 0;
        //플레이어 포지션과 enemy 포지션의 차를 이용해서 플레이어가 튕겨져 나갈 방향 계산
        if ((transform.position.x - targetPos.x) > 0) damDirc = -1;
        else damDirc = -1;
        
        //위 계산으로 나온 방향으로 플레이어에게 힘을 가함
        rigid.AddForce(new Vector2(damDirc, 0f) * 40f, ForceMode2D.Impulse);
        
        anim.SetTrigger("doDamaged");
        
        //1초간 무적상태
        Invoke("OffDamaged",1f);
    }

    //무적 판정
    void OffDamaged()
    {
        gameObject.layer = 0;
        spRenderer.color = new Color(1, 1, 1, 1);
    }
}

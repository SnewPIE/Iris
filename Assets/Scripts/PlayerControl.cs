using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float playerSpeed; //플레이어 속도
    float playerJumpHeight; //플레이어 점프높이
    int airJumpChance; //플레이어 최대 점프 횟수
    bool isDash; //대시 사용여부
    bool canDash;
    public bool onAir;
    public float dashCoolTime;
    public float dashDuration;
    public float dashSpeed;
    int dashDirection;
    int airDashChance;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        playerSpeed = 5.0f;
        playerJumpHeight = 8.0f;
        airJumpChance = 1;
        airDashChance = 1;
        canDash = true;
        isDash = false;
        onAir = false;
        dashCoolTime = 0.3f;
        dashDuration = 0.5f;
        dashSpeed = 10f;
        dashDirection = 1;
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();
        PlayerMotion();
        PlayerDash();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onAir = false;

        airDashChance = 1;
        airJumpChance = 1;
        //땅에 닿으면 점프횟수 초기화
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onAir = true;

    }

    //플레이어 움직임 관리
    private void PlayerMovement()
    {
        //대시중이면 작동안함
        if(isDash)
        {
            return;
        }
        //h=좌우키 입력방향
        float h = Input.GetAxisRaw("Horizontal");
        //대시 미발동시 기본 이동속도
        rigid.velocity = new Vector2(h * playerSpeed, rigid.velocity.y);
        
        //플레이어 스프라이트 x축 회전
        if(h>0)
        {
            spriteRenderer.flipX = false;
            dashDirection = 1;
        }
        else if(h<0)
        {
            spriteRenderer.flipX=true;
            dashDirection = -1;
        }
    }

    //플레이어 대쉬 구현
    private void PlayerDash()
    {
        if (Input.GetKey(KeyCode.LeftShift)&&canDash)
        {
            if(onAir)
            {
                if(airDashChance<=0)
                {
                    return;
                }
                airDashChance -= 1;
            }
            StartCoroutine(Dash());
        }

    }

    //플레이어 점프 구현
    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(onAir)
            {
                if(airJumpChance<=0)
                {
                    return;
                }
                airJumpChance -= 1;
            }
            rigid.velocity = new Vector2(rigid.velocity.x, playerJumpHeight);
        }
    }

    //플레이어 애니메이션
    private void PlayerMotion()
    {
        //플레이어 걷기
        if (rigid.velocity.x == 0)
        {
            animator.SetBool("isWalk", false);
        }
        else
        {
            animator.SetBool("isWalk", true);
        }
    }
    
    private IEnumerator Dash()
    {
        canDash = false;
        isDash = true;
        float originalGravity = rigid.gravityScale;
        rigid.gravityScale = 0f;
        rigid.velocity = new Vector2(transform.localScale.x * dashSpeed * dashDirection, 0f);

        yield return new WaitForSeconds(dashDuration);

        rigid.gravityScale = originalGravity;
        isDash=false;

        yield return new WaitForSeconds(dashCoolTime);
        canDash = true;
    }
}

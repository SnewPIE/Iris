using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    /*
    float enermySpeed;//적 속도
    float enermyJumpHeight;//적 점프높이
    float enermySightLenght;//적 시야 길이
    float enermySightHeight;//적 시야 높이
    bool isFind;//플레이어 발견 유무

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator animator;

    public Ghost ghost;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
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

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //땅에 트리거가 닿으면 점프/대시 초기화

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //땅에서 떨어질 때

    }

    //플레이어 움직임 관리
    private void PlayerMovement()
    {
        //대시중이면 작동안함

        //h=좌우키 입력방향

        //대시 미발동시 기본 이동속도
        rigid.velocity = new Vector2(h * playerSpeed, rigid.velocity.y);

        //플레이어 스프라이트 x축 회전
        if (h > 0)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1);
            dashDirection = 1;
        }
        else if (h < 0)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1);
            dashDirection = -1;
        }
    }

    //플레이어 대쉬 구현
    private void PlayerDash()
    {
        if (Input.GetKey(KeyCode.LeftShift) && canDash)
        {
            if (onAir)
            {
                if (airDashChance <= 0)
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
            if (onAir)
            {
                if (airJumpChance <= 0)
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
        ghost.makeGhost = true;
        float originalGravity = rigid.gravityScale;
        rigid.gravityScale = 0f;
        rigid.velocity = new Vector2(transform.localScale.x * dashSpeed, 0f);

        yield return new WaitForSeconds(dashDuration);

        rigid.gravityScale = originalGravity;
        isDash = false;
        ghost.makeGhost = false;

        yield return new WaitForSeconds(dashCoolTime);
        canDash = true;
    }
    */
}

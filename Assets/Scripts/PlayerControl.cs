using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float playerSpeed; //�÷��̾� �ӵ�
    float playerJumpHeight; //�÷��̾� ��������
    int airJumpChance; //�÷��̾� �ִ� ���� Ƚ��
    bool isDash; //��� ��뿩��
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
        //���� ������ ����Ƚ�� �ʱ�ȭ
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onAir = true;

    }

    //�÷��̾� ������ ����
    private void PlayerMovement()
    {
        //������̸� �۵�����
        if(isDash)
        {
            return;
        }
        //h=�¿�Ű �Է¹���
        float h = Input.GetAxisRaw("Horizontal");
        //��� �̹ߵ��� �⺻ �̵��ӵ�
        rigid.velocity = new Vector2(h * playerSpeed, rigid.velocity.y);
        
        //�÷��̾� ��������Ʈ x�� ȸ��
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

    //�÷��̾� �뽬 ����
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

    //�÷��̾� ���� ����
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

    //�÷��̾� �ִϸ��̼�
    private void PlayerMotion()
    {
        //�÷��̾� �ȱ�
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

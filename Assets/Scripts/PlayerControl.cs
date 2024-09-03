using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float playerSpeed; //�÷��̾� �ӵ�
    float playerJumpHeight; //�÷��̾� ��������
    int playerJumpChance; //�÷��̾� �ִ� ���� Ƚ��
    int JumpCount;
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
        playerJumpChance = 2;
        JumpCount = 0;
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //�÷��̾� ��������Ʈ �¿� ����
        if ( Input.GetButtonDown("Horizontal") )
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        //�÷��̾� ���� ����
        if(Input.GetKeyDown(KeyCode.Space)&& playerJumpChance>JumpCount)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, playerJumpHeight);
            //rigid.AddForce(Vector2.up*playerJumpHeight,ForceMode2D.Impulse);
            JumpCount++;
        }

        if(rigid.velocity.x == 0)
        {
            animator.SetBool("isWalk",false);
        }
        else
        {
            animator.SetBool("isWalk", true);
        }
    }

    private void FixedUpdate()
    {
        //h=�¿�Ű �Է¹���
        float h = Input.GetAxisRaw("Horizontal");
        //�Է� �������� �÷��̾� ���ǵ�� �̵�
        rigid.velocity= new Vector2 (h*playerSpeed, rigid.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            JumpCount = 0;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float playerSpeed; //�÷��̾� �ӵ�
    float playerJumpHeight; //�÷��̾� ��������
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        playerSpeed = 5.0f;
        playerJumpHeight = 8.0f;
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, playerJumpHeight);
            //rigid.AddForce(Vector2.up*playerJumpHeight,ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        //h=�¿�Ű �Է¹���
        float h = Input.GetAxisRaw("Horizontal");
        //�Է� �������� �÷��̾� ���ǵ�� �̵�
        rigid.velocity= new Vector2 (h*playerSpeed, rigid.velocity.y);
    }
}

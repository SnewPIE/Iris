using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float playerSpeed; //플레이어 속도
    float playerJumpHeight; //플레이어 점프높이
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
        //플레이어 스프라이트 좌우 반전
        if ( Input.GetButtonDown("Horizontal") )
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        //플레이어 점프 구현
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, playerJumpHeight);
            //rigid.AddForce(Vector2.up*playerJumpHeight,ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        //h=좌우키 입력방향
        float h = Input.GetAxisRaw("Horizontal");
        //입력 방향으로 플레이어 스피드로 이동
        rigid.velocity= new Vector2 (h*playerSpeed, rigid.velocity.y);
    }
}

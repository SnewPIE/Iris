using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    /*
    float enermySpeed;//�� �ӵ�
    float enermyJumpHeight;//�� ��������
    float enermySightLenght;//�� �þ� ����
    float enermySightHeight;//�� �þ� ����
    bool isFind;//�÷��̾� �߰� ����

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
        //���� Ʈ���Ű� ������ ����/��� �ʱ�ȭ

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //������ ������ ��

    }

    //�÷��̾� ������ ����
    private void PlayerMovement()
    {
        //������̸� �۵�����

        //h=�¿�Ű �Է¹���

        //��� �̹ߵ��� �⺻ �̵��ӵ�
        rigid.velocity = new Vector2(h * playerSpeed, rigid.velocity.y);

        //�÷��̾� ��������Ʈ x�� ȸ��
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

    //�÷��̾� �뽬 ����
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

    //�÷��̾� ���� ����
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

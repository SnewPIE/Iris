using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    
    float enermySpeed;//적 속도
    float enermyJumpHeight;//적 점프높이
    float enermySightLenght;//적 시야 길이
    float enermySightHeight;//적 시야 높이
    bool isFind;//플레이어 발견 유무
    int dir;//이동 방향
    Vector2 idleDir;//대기중일때 방향
    float nextDirTime;//이동 방향 변경 쿨타임
    public Transform enermyEye;//적 시야 시작지점


    private NavMeshAgent navAgent;
    private Transform Player;
    public float chaseDistance = 10f;
    private Vector3 startPosition;
    public float stopDistance = 2f;
    private Transform[] patrolPoints;
    private int currentPatrolIndex = 0;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        startPosition = transform.position;
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        nextDirTime = Random.Range(1.5f, 4f);
        enermySpeed = 1.0f;
        enermySightLenght = 10.0f;
        enermySightHeight = 0.5f;
        isFind = false;
        dir = 0;
        idleDir = Vector2.right;
        Invoke("ChangeDir", nextDirTime);
    }

    // Update is called once per frame
    void Update()
    {
        EnermySight();
        //PlayerJump();
        //PlayerMotion();
        //PlayerDash();
    }

    private void FixedUpdate()
    {
        EnermyMovement();
    }

    //적 움직임 관리
    private void EnermyMovement()
    {
        if(isFind ==true)
        {
            CancelInvoke();
        }
        else if (isFind == false)
        {
            //대시 미발동시 기본 이동속도
            rigid.velocity = new Vector2(enermySpeed * dir, rigid.velocity.y);

            //플레이어 스프라이트 x축 회전
            if (dir > 0)
            {
                transform.localScale = new Vector3(1.0f, 1.0f, 1);
                //dashDirection = 1;
            }
            else if (dir < 0)
            {
                transform.localScale = new Vector3(-1.0f, 1.0f, 1);
                //dashDirection = -1;
            }

            //낭떠러지 감지
            Vector2 frontVec = new Vector2(rigid.position.x + dir * 0.2f, rigid.position.y);
            //Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayhit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));
            if (rayhit.collider == null)
            {
                dir *= -1;
                CancelInvoke();
                Invoke("ChangeDir", nextDirTime);
            }
        }
    }

    //랜덤 움직임(좌우)
    private void ChangeDir()
    {
        dir = Random.Range(-1, 2);

        nextDirTime = Random.Range(1.5f, 4f);
        Invoke("ChangeDir", nextDirTime);
    }

    
    //적 시야 체크
    private void EnermySight()
    {
        //float distanceToPlayer = Vector3.Distance(Player.position, transform.position);
        if(dir > 0)
        {
            idleDir = Vector2.right;
        }
        else if (dir < 0)
        {
            idleDir = Vector2.left;
        }

        LayerMask check = (-1) - (1 << LayerMask.NameToLayer("Default"));

        Debug.DrawRay(enermyEye.position, idleDir, Color.red);
        RaycastHit2D sightray = Physics2D.Raycast(enermyEye.position, idleDir, enermySightLenght, check);
        //Vector2 boxSize = new Vector2(1.0f, enermySightHeight);
        //RaycastHit2D sightray1 = Physics2D.BoxCast(enermyEye.position, boxSize, 0, idleDir, enermySightLenght, check);


        if (sightray.collider!=null&&sightray.collider.tag=="Player")
        {
            Debug.Log("ccccccc");
        }
    }

    private void ChasePlayer(float distanceToPlayer)
    {
        if(distanceToPlayer <= stopDistance)
        {
            navAgent.isStopped = true;
        }
        else
        {
            navAgent.isStopped = false;
            navAgent.SetDestination(Player.position);
        }
    }

    /*
    void OnDrawGizmos()
    {
        Vector2 direction = idleDir;  // 박스캐스트 방향
        Vector2 size = new Vector2(1f, enermySightHeight);   // 박스 크기
        float distance = enermySightLenght;

        // 박스의 시작점
        Vector2 origin = enermyEye.position;

        // 박스의 끝점 계산
        Vector2 endPoint = origin + direction * distance;

        // 박스의 4개의 꼭짓점을 계산하여 그리기
        Vector2 topLeft = origin + new Vector2(-size.x / 2, size.y / 2);
        Vector2 topRight = origin + new Vector2(size.x / 2, size.y / 2);
        Vector2 bottomLeft = origin + new Vector2(-size.x / 2, -size.y / 2);
        Vector2 bottomRight = origin + new Vector2(size.x / 2, -size.y / 2);

        // 박스 그리기
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);

        // 박스의 이동 경로 그리기
        Gizmos.DrawLine(origin, endPoint);
    }


    /*
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

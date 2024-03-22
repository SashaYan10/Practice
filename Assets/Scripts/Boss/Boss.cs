using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float moveSpeed = 3f; // �������� ���� ������
    public float minMoveTime = 1f; // ̳�������� ��� ���� � ������ ��������
    public float maxMoveTime = 3f; // ������������ ��� ���� � ������ ��������
    public float turnSpeed = 5f; // �������� ��������� ������
    public float wallCheckDistance = 0.1f; // ³������ ��� �������� �������� ���� ����� �������
    public LayerMask wallLayer; // ��� ��� ���
    public Transform groundCheck; // ����� ��� �������� ����
    public float stoppingDistance = 5f; // ³������, �� ��� ����� ����������� ����� �������

    private Rigidbody2D rb;
    private bool facingRight = true; // �������� ������� ������ (�������� �� ������)
    private bool isGrounded; // ��������, �� ����� ����� �� ����
    private bool isMoving = true; // ��������, �� �������� �����
    private float moveTime; // ��� ���� � ������ ��������
    private float moveTimer; // ������ ��� ���� � ������ ��������

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10;
    public float fireRate = 0.5f;
    public int maxBullets = 10;
    public int bulletsLeft = 30;
    public float shootingDistance = 10f; // ���������, �� ��� ����� ���� ������� �� ������
    public int bulletsAfterReload = 30; // ʳ������ ������� ���� �����������
    public float reloadDelay = 1f; // �������� ����� �������� ������� ���� �����������

    private GameObject[] players;
    private bool canShoot = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveTime = Random.Range(minMoveTime, maxMoveTime);
        players = GameObject.FindGameObjectsWithTag("Player");
        StartCoroutine(ShootPlayer());
    }

    IEnumerator ShootPlayer()
    {
        while (true)
        {
            foreach (var player in players)
            {
                if (Vector2.Distance(transform.position, player.transform.position) < shootingDistance)
                {
                    if (canShoot && bulletsLeft > 0)
                    {
                        canShoot = false;
                        TurnToPlayer(player.transform.position);
                        Shoot(player.transform);
                        yield return new WaitForSeconds(fireRate);
                        canShoot = true;
                    }
                    else if (bulletsLeft == 0)
                    {
                        Reload();
                        yield return new WaitForSeconds(reloadDelay); // �������� ����� �������� ������� ���� �����������
                    }
                }
            }
            yield return null;
        }
    }

    void Update()
    {
        CheckGround();
        CheckWall();

        if (isMoving)
        {
            Move();
        }
        else
        {
            StopMoving();
        }
    }

    void CheckGround()
    {
        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
    }

    void CheckWall()
    {
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, wallCheckDistance, wallLayer);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, wallCheckDistance, wallLayer);

        if (hitRight || hitLeft)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }

    void Move()
    {
        moveTimer += Time.deltaTime;
        if (moveTimer >= moveTime)
        {
            Flip();
            moveTime = Random.Range(minMoveTime, maxMoveTime);
            moveTimer = 0f;
        }

        if (facingRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        foreach (var player in players)
        {
            if (Vector2.Distance(transform.position, player.transform.position) < stoppingDistance)
            {
                isMoving = false;
                rb.velocity = Vector2.zero; // ��������� ��� ������
                break;
            }
            else
            {
                isMoving = true;
            }
        }
    }

    void StopMoving()
    {
        rb.velocity = Vector2.zero;
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void TurnToPlayer(Vector3 playerPosition)
    {
        if (playerPosition.x < transform.position.x)
        {
            // ������� ���� �� ������, ���������� ������
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            // ������� ������ �� ������, ��������� ������������ ������
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    void Shoot(Transform target)
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Vector2 targetDirection = (target.position - bulletSpawnPoint.position).normalized; // �������� �� ������
        targetDirection.y = 0f; // ������������ Y-���������� �������� �� 0, ��� ���� ����� ����� �� �� X
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = targetDirection * bulletSpeed;
        bulletsLeft--;
    }

    void Reload()
    {
        bulletsLeft = bulletsAfterReload;
    }
}

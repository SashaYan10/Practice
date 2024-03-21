using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float moveSpeed = 3f; // Швидкість руху ворога
    public float minMoveTime = 1f; // Мінімальний час руху в одному напрямку
    public float maxMoveTime = 3f; // Максимальний час руху в одному напрямку
    public float turnSpeed = 5f; // Швидкість розвороту ворога
    public float wallCheckDistance = 0.1f; // Відстань для перевірки наявності стіни перед ворогом
    public LayerMask wallLayer; // Шар для стін
    public Transform groundCheck; // Точка для перевірки землі
    public float stoppingDistance = 5f; // Відстань, на якій ворог зупиняється перед гравцем

    private Rigidbody2D rb;
    private bool facingRight = true; // Напрямок обличчя ворога (праворуч чи ліворуч)
    private bool isGrounded; // Перевірка, чи стоїть ворог на землі
    private bool isMoving = true; // Перевірка, чи рухається ворог
    private float moveTime; // Час руху в одному напрямку
    private float moveTimer; // Таймер для руху в одному напрямку

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10;
    public float fireRate = 0.5f;
    public int maxBullets = 10;
    public int bulletsLeft = 30;
    public float shootingDistance = 10f; // Дистанція, на якій ворог буде стріляти до гравця
    public int bulletsAfterReload = 30; // Кількість патронів після перезарядки
    public float reloadDelay = 1f; // Затримка перед початком стрільби після перезарядки

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
                        yield return new WaitForSeconds(reloadDelay); // Почекати перед початком стрільби після перезарядки
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
                rb.velocity = Vector2.zero; // Зупиняємо рух ворога
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
            // Гравець зліва від ворога, зеркалюємо ворога
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            // Гравець справа від ворога, скасовуємо зеркалювання ворога
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    void Shoot(Transform target)
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Vector2 targetDirection = (target.position - bulletSpawnPoint.position).normalized; // Напрямок до гравця
        targetDirection.y = 0f; // Встановлюємо Y-компоненту напрямку на 0, щоб пуля летіла тільки по осі X
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = targetDirection * bulletSpeed;
        bulletsLeft--;
    }

    void Reload()
    {
        bulletsLeft = bulletsAfterReload;
    }
}

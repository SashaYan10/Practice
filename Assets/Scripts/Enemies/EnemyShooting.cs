using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10;
    public float fireRate = 0.5f;
    public int maxBullets = 10;
    public int bulletsLeft = 30;
    public float shootingDistance = 10f; // ���������, �� ��� ����� ���� ������� �� ������
    public int bulletsAfterReload = 30; // ʳ������ ������� ���� �����������
    public float reloadDelay = 1f; // �������� ����� �������� ������� ���� �����������
    public float turnSpeed = 5f; // �������� ��������� ������ �� ������

    private GameObject[] players;
    private bool canShoot = true;

    void Start()
    {
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

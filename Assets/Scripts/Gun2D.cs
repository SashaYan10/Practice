using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2D : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float fireRate = 0.1f;
    public int maxBullets = 10;

    private bool isShooting = false;
    private int bulletsFired = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && bulletsFired < maxBullets)
        {
            isShooting = true;
            StartCoroutine(ShootBullets());
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isShooting = false;
            bulletsFired = 0;
        }
    }

    IEnumerator ShootBullets()
    {
        while (isShooting && bulletsFired < maxBullets)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (transform.localScale.x < 0)
            {
                rb.velocity = -bulletSpawnPoint.right * bulletSpeed;
            }
            else
            {
                rb.velocity = bulletSpawnPoint.right * bulletSpeed;
            }
            bulletsFired++;
            yield return new WaitForSeconds(fireRate);
        }
    }
}

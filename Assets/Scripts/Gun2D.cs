using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun2D : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float fireRate = 0.1f;
    public int maxBullets = 10;
    public int bulletsLeft = 30;

    public Text bulletsLeftText;

    private bool isShooting = false;
    private int bulletsFired = 0;

    void Start()
    {
        UpdateBulletsLeftText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && bulletsFired < maxBullets && bulletsLeft > 0)
        {
            isShooting = true;
            StartCoroutine(ShootBullets());
        }
        else if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < 30)
        {
            Reload();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isShooting = false;
            bulletsFired = 0;
        }
    }

    IEnumerator ShootBullets()
    {
        while (isShooting && bulletsFired < maxBullets && bulletsLeft > 0)
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
            bulletsLeft--;
            UpdateBulletsLeftText();
            yield return new WaitForSeconds(fireRate);
        }
    }

    void Reload()
    {
        bulletsLeft = 30;
        UpdateBulletsLeftText();
    }

    void UpdateBulletsLeftText()
    {
        if (bulletsLeftText != null)
        {
            bulletsLeftText.text = bulletsLeft.ToString() + "/30";
        }
    }
}

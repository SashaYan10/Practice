using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RPG : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float fireRate = 0.1f;
    public int maxBullets = 1;
    public int bulletsLeft = 1;
    public float reloadDelay = 2.0f; // Час перезарядки

    public Text bulletsLeftText;

    private bool isShooting = false;
    private int bulletsFired = 0;
    private bool isReloading = false;
    private float reloadTimer = 0.0f;

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
        else if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < 1 && !isReloading)
        {
            isReloading = true;
            reloadTimer = reloadDelay;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isShooting = false;
            bulletsFired = 0;
        }

        if (isReloading)
        {
            reloadTimer -= Time.deltaTime;
            if (reloadTimer <= 0)
            {
                Reload();
                isReloading = false;
            }
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
        bulletsLeft = 1;
        UpdateBulletsLeftText();
    }

    void UpdateBulletsLeftText()
    {
        if (bulletsLeftText != null)
        {
            bulletsLeftText.text = bulletsLeft.ToString() + "/1";
        }
    }
}

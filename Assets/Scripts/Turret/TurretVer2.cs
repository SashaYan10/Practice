using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretVer2 : MonoBehaviour
{
    public float Range;
    Transform target; // Зміна типу Transform для пошуку цілі

    bool Detected = false;
    Vector2 Direction;

    public GameObject AlarmLight;
    public GameObject Gun;
    public GameObject Bullet;
    public float FireRate;
    float nextTimeToFire = 0;
    public Transform ShootPoint;
    public float Force;

    void Update()
    {
        FindTarget(); // Знаходження цілі кожен кадр

        if (target != null) // Перевірка наявності цілі
        {
            Vector2 targetPos = target.position;
            Direction = targetPos - (Vector2)transform.position;

            RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);

            if (rayInfo && rayInfo.collider.gameObject.tag == "Player")
            {
                if (!Detected)
                {
                    Detected = true;
                    AlarmLight.GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
            else
            {
                if (Detected)
                {
                    Detected = false;
                    AlarmLight.GetComponent<SpriteRenderer>().color = Color.green;
                }
            }

            if (Detected)
            {
                Gun.transform.up = Direction;
                if (Time.time > nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1 / FireRate;
                    Shoot();
                }
            }
        }
    }

    void FindTarget()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            target = null;
        }
    }

    void Shoot()
    {
        GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}

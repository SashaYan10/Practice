using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 40;

    private Material matBlink;
    private Material matDefault;
    private SpriteRenderer spriteRend;

    private UnityEngine.Object explosion;

    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();

        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        matDefault = spriteRend.material;

        explosion = Resources.Load("Explosion");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            health--;

            spriteRend.material = matBlink;

            if (health <= 0)
            {
                //kill
                KillEnemy();
            }
            else
            {
                Invoke("ResetMaterial", .05f);
            }
        }
        else if (collision.CompareTag("RPGBullet")) // Додано перевірку тегу RPGBullet
        {
            Destroy(collision.gameObject);
            health -= 10; // Зменшення здоров'я на 10 одиниць

            spriteRend.material = matBlink;

            if (health <= 0)
            {
                //kill
                KillEnemy();
            }
            else
            {
                Invoke("ResetMaterial", .05f);
            }
        }
    }


    void ResetMaterial()
    {
        spriteRend.material = matDefault;
    }

    void KillEnemy()
    {
        GameObject explosionRef = (GameObject)Instantiate(explosion);
        explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private int health = 40;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            health++;

            if (health <= 0)
            {
                //kill
                KillEnemy();
            }
        }
    }

    void KillEnemy()
    {
        Destroy(gameObject);
    }
}

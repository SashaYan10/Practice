using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKatanaBulletDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Transform parentTransform = transform.parent;
            parentTransform.GetComponent<Enemy>().TakeBulletDamage(0);
            

           
        }
        else if (collision.CompareTag("RPGBullet")) // Додано перевірку тегу RPGBullet
        {
            Destroy(collision.gameObject);
            Transform parentTransform = transform.parent;
            parentTransform.GetComponent<Enemy>().TakeBulletDamage(0);
        }
    }
}

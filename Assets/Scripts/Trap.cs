using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    Rigidbody2D rb;
    public bool sceneLoad;
    public int sceneIndex = 0;
    public GameObject destructionEffectPrefab; // Посилання на префаб ефекту

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Character"))
        {
            rb.isKinematic = false;
        }
        else if (collision.gameObject.tag.Equals("Ground"))
        {
            Debug.Log("Platform destroyed");
            Instantiate(destructionEffectPrefab, transform.position, Quaternion.identity); // Відтворення ефекту
            Destroy(gameObject); // Знищення платформи
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (sceneLoad==true)
        {
            if (collision.gameObject.name.Equals("Character"))
            {
                Debug.Log("Game Over");
                SceneManager.LoadScene(sceneIndex);
            }
            else if (collision.gameObject.tag.Equals("Ground"))
            {
                Debug.Log("Platform destroyed");
                Instantiate(destructionEffectPrefab, transform.position, Quaternion.identity); // Відтворення ефекту
                Destroy(gameObject); // Знищення платформи
            }
        }
    }
}

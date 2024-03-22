using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPBar : MonoBehaviour
{
    public Image HealthImage;
    private float HealthCount = 1000f;
    public float damageGunBullet;
    public float damageRPGBullet;
    public string gameOverSceneName;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            HealthCount -= damageGunBullet;
            HealthImage.fillAmount = HealthCount / 100f;
        }
        else if (collision.CompareTag("RPGEnemyBullet"))
        {
            HealthCount -= damageRPGBullet;
            HealthImage.fillAmount = HealthCount / 100f;
        }

        CheckHealth();
    }

    void CheckHealth()
    {
        if (HealthCount <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }
    public void TakeKatanaDamage(float Damage)
    {
        HealthCount -= Damage;
        if (HealthCount <= 0)
        {
            GameOver();
        }
        HealthImage.fillAmount = HealthCount / 100f;
    }
}

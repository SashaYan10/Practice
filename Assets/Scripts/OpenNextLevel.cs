using UnityEngine;

public class OpenNextLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyObjects;
    [SerializeField] private GameObject objectToRise;
    private bool allEnemiesDestroyed = false;


    void Update()
    {
        CheckEnemiesDestroyed();
        if (allEnemiesDestroyed)
        {
            RiseObject();
        }
    }

    void CheckEnemiesDestroyed()
    {
        allEnemiesDestroyed = true;
        foreach (GameObject enemy in enemyObjects)
        {
            if (enemy != null)
            {
                allEnemiesDestroyed = false;
                break;
            }
        }
    }

    void RiseObject()
    {
        float speed = 0.5f;

        // Отримуємо початкову позицію ліфта
        Vector3 startPosition = transform.position;

        // Отримуємо цільову позицію ліфта
        Vector3 targetPosition = new Vector3(startPosition.x, startPosition.y + 9.0f, startPosition.z);

        // Переміщуємо ліфт до цільової позиції
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
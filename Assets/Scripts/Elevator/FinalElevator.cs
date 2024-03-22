using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalElevator : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("InElevator");
            // Запускаємо корутину для переміщення ліфта
            StartCoroutine(MoveElevator());
        }
    }

    private IEnumerator MoveElevator()
    {
        yield return new WaitForSeconds(2);
        // Визначаємо швидкість переміщення
        float speed = 2.0f;

        // Отримуємо початкову позицію ліфта
        Vector3 startPosition = transform.position;

        // Отримуємо цільову позицію ліфта
        Vector3 targetPosition = new Vector3(startPosition.x, startPosition.y + 20.0f, startPosition.z);

        // Переміщуємо ліфт до цільової позиції
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}

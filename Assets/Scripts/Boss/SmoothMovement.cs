using UnityEngine;

public class SmoothMovement : MonoBehaviour
{
    public Transform objectToMove; // Посилання на об'єкт, який буде рухатися
    public float targetYPosition; // Цільова позиція по осі Y
    public float moveSpeed = 2f; // Швидкість руху об'єкта
    public GameObject objectToDestroy; // Посилання на об'єкт, який потрібно знищити

    private bool isMoving = false; // Прапорець, щоб визначати, чи об'єкт рухається

    void Update()
    {
        if (isMoving)
        {
            MoveObject();
        }
    }

    public void StartMoving()
    {
        isMoving = true;
        DestroyObject();
    }

    void MoveObject()
    {
        float step = moveSpeed * Time.deltaTime; // Визначаємо швидкість руху на кожному кадрі
        objectToMove.position = Vector3.MoveTowards(objectToMove.position, new Vector3(objectToMove.position.x, targetYPosition, objectToMove.position.z), step);

        if (objectToMove.position.y == targetYPosition)
        {
            isMoving = false; // Якщо об'єкт досягнув цільової позиції, зупиняємо рух
        }
    }

    void DestroyObject()
    {
        if (objectToDestroy != null)
        {
            Destroy(objectToDestroy); // Знищуємо об'єкт зі сцени
        }
    }
}

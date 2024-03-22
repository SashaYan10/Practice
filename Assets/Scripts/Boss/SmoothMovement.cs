using UnityEngine;

public class SmoothMovement : MonoBehaviour
{
    public Transform objectToMove; // ��������� �� ��'���, ���� ���� ��������
    public float targetYPosition; // ֳ����� ������� �� �� Y
    public float moveSpeed = 2f; // �������� ���� ��'����
    public GameObject objectToDestroy; // ��������� �� ��'���, ���� ������� �������

    private bool isMoving = false; // ���������, ��� ���������, �� ��'��� ��������

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
        float step = moveSpeed * Time.deltaTime; // ��������� �������� ���� �� ������� ����
        objectToMove.position = Vector3.MoveTowards(objectToMove.position, new Vector3(objectToMove.position.x, targetYPosition, objectToMove.position.z), step);

        if (objectToMove.position.y == targetYPosition)
        {
            isMoving = false; // ���� ��'��� �������� ������� �������, ��������� ���
        }
    }

    void DestroyObject()
    {
        if (objectToDestroy != null)
        {
            Destroy(objectToDestroy); // ������� ��'��� � �����
        }
    }
}

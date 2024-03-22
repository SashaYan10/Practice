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
            // ��������� �������� ��� ���������� ����
            StartCoroutine(MoveElevator());
        }
    }

    private IEnumerator MoveElevator()
    {
        yield return new WaitForSeconds(2);
        // ��������� �������� ����������
        float speed = 2.5f;

        // �������� ��������� ������� ����
        Vector3 startPosition = transform.position;

        // �������� ������� ������� ����
        Vector3 targetPosition = new Vector3(startPosition.x, startPosition.y + 20.0f, startPosition.z);

        // ��������� ��� �� ������� �������
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}

using UnityEngine;

public class OpenNextLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyObjects;
    [SerializeField] private Transform objectToRise; // ������ � GameObject �� Transform ��� ������������ ��������� �� SmoothMovement
    private bool allEnemiesDestroyed = false;

    private bool isRising = false; // ���������, ��� ���������, �� ��'��� ���������
    private float riseSpeed = 2.0f; // �������� ������ ��'����

    void Update()
    {
        CheckEnemiesDestroyed();
        if (allEnemiesDestroyed && !isRising) // ������ �������� �� isRising, ��� ������ ��'��� ����� ���� ���
        {
            StartRising();
        }

        if (isRising)
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

    void StartRising()
    {
        isRising = true;
    }

    void RiseObject()
    {
        float step = riseSpeed * Time.deltaTime;
        objectToRise.position = Vector3.MoveTowards(objectToRise.position, new Vector3(objectToRise.position.x, objectToRise.position.y + 2.0f, objectToRise.position.z), step);

        if (objectToRise.position.y >= objectToRise.position.y + 2.0f)
        {
            isRising = false;
        }
    }
}

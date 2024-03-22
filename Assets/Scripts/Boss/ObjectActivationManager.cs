using UnityEngine;
using UnityEngine.UI;

public class ObjectActivationManager : MonoBehaviour
{
    public GameObject objectToKeepActive;
    public Button hideButton;
    private bool objectsDeactivated = false;

    private void Start()
    {
        // ������ �������� ��䳿 ��� ������ ������������
        if (hideButton != null)
        {
            hideButton.onClick.AddListener(ToggleObjectVisibility);
        }
        else
        {
            Debug.LogWarning("Hide Button not assigned.");
        }
    }

    private void ToggleObjectVisibility()
    {
        // ����������, �� ��'���� ��� �����������
        if (objectsDeactivated)
        {
            ActivateAllDeactivatedObjects();
        }
        else
        {
            DeactivateAllObjectsExceptOne();
        }

        objectsDeactivated = !objectsDeactivated;
    }

    private void DeactivateAllObjectsExceptOne()
    {
        // �������� �� ��'���� � ��������
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            // ���� �� �� ��'���, ���� ����� �������� ��������, �� ���������� ����
            if (obj != objectToKeepActive)
            {
                obj.SetActive(false);
            }
        }
    }

    public void ActivateAllDeactivatedObjects()
    {
        // �������� �� ��'���� � ��������
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            // �������� �� ����������� ��'����
            obj.SetActive(true);
        }
    }
}

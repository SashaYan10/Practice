using UnityEngine;

public class PauseOnPanelActivation : MonoBehaviour
{
    public GameObject panel; // ��������� �� ������, ��� ������ ���������� ������ ��'����
    public GameObject objectToHide; // ��������� �� ��'���, ���� ������� ���������

    void Update()
    {
        if (panel.activeSelf)
        {
            objectToHide.SetActive(false); // ��������� ��'���, ���� ������ �������
            Time.timeScale = 0f; // ��������� ��� � �� (�����)
        }
        else
        {
            objectToHide.SetActive(true); // �������� ��'���, ���� ������ �� �������
            Time.timeScale = 1f; // ���������� ���, ���� ������ �� �������
        }
    }
}

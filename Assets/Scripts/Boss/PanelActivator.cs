using UnityEngine;

public class PanelActivator : MonoBehaviour
{
    public GameObject panel; // ��������� �� ������, ��� ������� ����������

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(false);
        }
    }
}

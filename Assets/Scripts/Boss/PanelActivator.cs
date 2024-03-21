using UnityEngine;

public class PanelActivator : MonoBehaviour
{
    public GameObject panel; // посилання на панель, яку потрібно активувати

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

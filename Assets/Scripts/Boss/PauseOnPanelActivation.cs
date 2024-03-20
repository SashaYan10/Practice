using UnityEngine;

public class PauseOnPanelActivation : MonoBehaviour
{
    public GameObject panel; // посилання на панель, яка активує приховання іншого об'єкта
    public GameObject objectToHide; // посилання на об'єкт, який потрібно приховати

    void Update()
    {
        if (panel.activeSelf)
        {
            objectToHide.SetActive(false); // приховуємо об'єкт, коли панель активна
            Time.timeScale = 0f; // зупиняємо час у грі (пауза)
        }
        else
        {
            objectToHide.SetActive(true); // показуємо об'єкт, якщо панель не активна
            Time.timeScale = 1f; // відновлюємо час, якщо панель не активна
        }
    }
}

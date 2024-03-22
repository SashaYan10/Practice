using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public Text timerText; // Посилання на текстове поле таймера в інспекторі
    public float timeInSeconds = 60f; // Час у секундах, який можна змінювати в інспекторі
    public int sceneIndexToLoad = 1; // Індекс сцени для завантаження в інспекторі

    public GameObject panelToShow; // Посилання на панель, яка повинна з'явитися в інспекторі
    public float panelAppearTime = 30f; // Час у секундах для появи панелі, змінюваний в інспекторі

    private bool timerRunning = true;

    void Update()
    {
        if (timerRunning)
        {
            if (timeInSeconds > 0)
            {
                timeInSeconds -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {
                LoadSceneByIndex();
            }
        }

        // Перевіряємо, чи активована панель, і приховуємо таймер, якщо так
        if (panelToShow != null && panelToShow.activeSelf)
        {
            timerText.gameObject.SetActive(false); // Приховуємо текстове поле таймера
            timerRunning = false; // Зупиняємо таймер
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void LoadSceneByIndex()
    {
        SceneManager.LoadScene(sceneIndexToLoad);
    }

    public void ButtonPressAction() // Метод, який викликається при натисканні кнопки, яка відповідає за панель
    {
        if (panelToShow != null)
        {
            panelToShow.SetActive(true); // Показуємо панель
            timerRunning = false; // Зупиняємо таймер
        }
    }
}

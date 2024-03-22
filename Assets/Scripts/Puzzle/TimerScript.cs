using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public Text timerText; // ��������� �� �������� ���� ������� � ���������
    public float timeInSeconds = 60f; // ��� � ��������, ���� ����� �������� � ���������
    public int sceneIndexToLoad = 1; // ������ ����� ��� ������������ � ���������

    public GameObject panelToShow; // ��������� �� ������, ��� ������� �'������� � ���������
    public float panelAppearTime = 30f; // ��� � �������� ��� ����� �����, ��������� � ���������

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

        // ����������, �� ���������� ������, � ��������� ������, ���� ���
        if (panelToShow != null && panelToShow.activeSelf)
        {
            timerText.gameObject.SetActive(false); // ��������� �������� ���� �������
            timerRunning = false; // ��������� ������
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

    public void ButtonPressAction() // �����, ���� ����������� ��� ��������� ������, ��� ������� �� ������
    {
        if (panelToShow != null)
        {
            panelToShow.SetActive(true); // �������� ������
            timerRunning = false; // ��������� ������
        }
    }
}

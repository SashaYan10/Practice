using UnityEngine;

public class ActivePlayer : MonoBehaviour
{
    private GameObject playerObject;
    private bool isPlayerVisible = true;

    void Start()
    {
        // Знаходимо об'єкт з тегом "Player" при запуску скрипту
        playerObject = GameObject.FindGameObjectWithTag("PlayerCanvas");
        if (playerObject == null)
        {
            Debug.LogError("Об'єкт з тегом 'Player' не знайдено на сцені!");
        }
    }

    public void ToggleVisibility()
    {
        if (playerObject != null)
        {
            isPlayerVisible = !isPlayerVisible;
            playerObject.SetActive(isPlayerVisible);
        }
    }
}

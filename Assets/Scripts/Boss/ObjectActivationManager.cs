using UnityEngine;
using UnityEngine.UI;

public class ObjectActivationManager : MonoBehaviour
{
    public GameObject objectToKeepActive;
    public Button hideButton;
    private bool objectsDeactivated = false;

    private void Start()
    {
        // Додаємо обробник події для кнопки приховування
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
        // Перевіряємо, чи об'єкти вже деактивовані
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
        // Отримуємо всі об'єкти в ієрархії
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            // Якщо це не об'єкт, який треба зберегти активним, то деактивуємо його
            if (obj != objectToKeepActive)
            {
                obj.SetActive(false);
            }
        }
    }

    public void ActivateAllDeactivatedObjects()
    {
        // Отримуємо всі об'єкти в ієрархії
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            // Активуємо всі деактивовані об'єкти
            obj.SetActive(true);
        }
    }
}

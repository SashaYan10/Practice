using UnityEngine;
using UnityEngine.EventSystems;
using System.Diagnostics;

public class OpenURLOnClick : MonoBehaviour, IPointerClickHandler
{
    public string url = "https://www.example.com";

    public void OnPointerClick(PointerEventData eventData)
    {
        OpenURL();
    }

    public void OpenURL()
    {
        Process.Start(url); // Відкриття URL у браузері
    }
}

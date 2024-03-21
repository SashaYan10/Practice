using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public int fullElementToWin = 12; // Кількість кусків пазла для перевірки в інспекторі
    public static int myElement;
    public GameObject myPanel;
    public GameObject winPanel;

    // Update is called once per frame
    void Update()
    {
        if (myElement >= fullElementToWin) // Перевірка кількості поставлених кусків пазла для перемоги
        {
            winPanel.SetActive(true);
        }
    }

    public static void AddElement()
    {
        myElement++;
    }
}

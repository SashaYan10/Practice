using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public int fullElementToWin = 12; // ʳ������ ����� ����� ��� �������� � ���������
    public static int myElement;
    public GameObject myPanel;
    public GameObject winPanel;

    // Update is called once per frame
    void Update()
    {
        if (myElement >= fullElementToWin) // �������� ������� ����������� ����� ����� ��� ��������
        {
            winPanel.SetActive(true);
        }
    }

    public static void AddElement()
    {
        myElement++;
    }
}

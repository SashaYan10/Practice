using UnityEngine;

public class CameraSwitchButton : MonoBehaviour
{
    public Camera activeCamera; // ��������� �� ������, ��� ����� ����������

    public void SwitchCameras()
    {
        // ������ ������� ������ � �������� �����
        Camera[] allCameras = FindObjectsOfType<Camera>();
        foreach (Camera cam in allCameras)
        {
            if (cam.gameObject.activeSelf)
            {
                // ������������ ������� ������
                cam.gameObject.SetActive(false);
                break;
            }
        }

        // ���������� ���� ������
        activeCamera.gameObject.SetActive(true);
    }
}

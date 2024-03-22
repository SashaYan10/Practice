using UnityEngine;

public class CameraSwitchButton : MonoBehaviour
{
    public Camera activeCamera; // Посилання на камеру, яку треба активувати

    public void SwitchCameras()
    {
        // Знайти активну камеру в ієрархії сцени
        Camera[] allCameras = FindObjectsOfType<Camera>();
        foreach (Camera cam in allCameras)
        {
            if (cam.gameObject.activeSelf)
            {
                // Деактивувати активну камеру
                cam.gameObject.SetActive(false);
                break;
            }
        }

        // Активувати нову камеру
        activeCamera.gameObject.SetActive(true);
    }
}

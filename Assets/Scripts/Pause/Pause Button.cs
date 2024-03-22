using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public static bool GameOnPause = true;
    public GameObject PauseButtonUI;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        PauseButtonUI.SetActive(true);
        Time.timeScale = 0;
        GameOnPause = true;
    }
}

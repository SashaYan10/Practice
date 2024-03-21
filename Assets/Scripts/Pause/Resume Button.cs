using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public static bool GameOnPause = false;
    public GameObject resumeButtonUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameOnPause)
                return;
            else
                ResumeGame();
        }
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        GameOnPause = false;
    }
}

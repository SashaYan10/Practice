using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance;
    public List<int> scenesToDestroy;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (scenesToDestroy.Contains(currentSceneIndex))
        {
            Destroy(gameObject);
        }
    }
}

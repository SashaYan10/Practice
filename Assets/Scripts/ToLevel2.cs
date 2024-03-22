using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevel2 : MonoBehaviour
{
    [SerializeField] private string NextLevel;

    private void Start()
    {
        StartCoroutine(WaitAndLoad());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(NextLevel);
        }
    }

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(22);
        SceneManager.LoadScene(NextLevel);
    }
}

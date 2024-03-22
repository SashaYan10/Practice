using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private string NextLevel;

    private void Start()
    {
        StartCoroutine(WaitAndLoad());
    }

    private void Update()
    {
        NextLevel = "Melee_attack_level";
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(NextLevel);
        }
    }

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(66);
        SceneManager.LoadScene(NextLevel);
    }
}

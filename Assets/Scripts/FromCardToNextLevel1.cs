using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromCardToNextLevel1 : MonoBehaviour
{
    [SerializeField] private string NextLevel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndLoad());
    }

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(NextLevel);
    }
}
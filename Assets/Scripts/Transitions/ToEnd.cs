using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToEnd : MonoBehaviour
{
    public string NextLevel;
    public BlackScreen BlackScreen;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("ToNextScene");
            StartCoroutine(WaitAndLoad());
        }
    }

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(5);
        BlackScreen.Showed = true;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(NextLevel);
    }
}

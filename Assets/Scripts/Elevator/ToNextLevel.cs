using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishProcessing : MonoBehaviour
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
        BlackScreen.Showed = true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(NextLevel);
    }
}

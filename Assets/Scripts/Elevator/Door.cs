using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject DoorOpened;
    public GameObject DoorClosed;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("OnTriggerEnter2D");
            StartCoroutine(WaitAndLoad());
        }
    }

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(1);
        DoorOpened.SetActive(false);
        DoorClosed.SetActive(true);
    }
}

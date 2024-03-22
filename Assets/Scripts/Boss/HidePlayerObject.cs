using UnityEngine;

public class HidePlayerObject : MonoBehaviour
{
    public void HidePlayer()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Player object not found in the scene!");
        }
    }
}

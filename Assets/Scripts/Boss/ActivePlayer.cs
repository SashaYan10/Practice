using UnityEngine;

public class ActivePlayer : MonoBehaviour
{
    private GameObject playerObject;
    private bool isPlayerVisible = true;

    void Start()
    {
        // ��������� ��'��� � ����� "Player" ��� ������� �������
        playerObject = GameObject.FindGameObjectWithTag("PlayerCanvas");
        if (playerObject == null)
        {
            Debug.LogError("��'��� � ����� 'Player' �� �������� �� ����!");
        }
    }

    public void ToggleVisibility()
    {
        if (playerObject != null)
        {
            isPlayerVisible = !isPlayerVisible;
            playerObject.SetActive(isPlayerVisible);
        }
    }
}

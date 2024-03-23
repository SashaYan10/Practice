using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionScript : MonoBehaviour
{
    public GameObject playerPrefabGun;
    public GameObject playerPrefabRPG;
    public GameObject playerPrefabKatana;
    public Transform spawnPoint;

    public void SelectCharacterGun()
    {
        PlayerPrefs.SetInt("SelectedCharacter", 1);
        LoadNextScene();
    }

    public void SelectCharacterRPG()
    {
        PlayerPrefs.SetInt("SelectedCharacter", 2);
        LoadNextScene();
    }

    public void SelectCharacterKatana()
    {
        PlayerPrefs.SetInt("SelectedCharacter", 3);
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void SpawnCharacter()
    {
        GameObject playerPrefab = null;
        if (PlayerPrefs.GetInt("SelectedCharacter") == 1)
        {
            playerPrefab = playerPrefabGun;
        }
        if (PlayerPrefs.GetInt("SelectedCharacter") == 2)
        {
            playerPrefab = playerPrefabRPG;
        }
        if (PlayerPrefs.GetInt("SelectedCharacter") == 3)
        {
            playerPrefab = playerPrefabKatana;
        }
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    private void Start()
    {
        SpawnCharacter();
    }
}

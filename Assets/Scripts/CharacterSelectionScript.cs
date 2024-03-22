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

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void SpawnCharacter()
    {
        GameObject playerPrefab = PlayerPrefs.GetInt("SelectedCharacter") == 1 ? playerPrefabGun : playerPrefabRPG;
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    private void Start()
    {
        SpawnCharacter();
    }
}

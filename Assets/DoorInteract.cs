using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteract : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int currentLevel = PlayerPrefs.GetInt("LevelUnlocked");

            if (currentLevel == 0)
                PlayerPrefs.SetInt("LevelUnlocked", 1);

            PlayerPrefs.SetInt("LevelUnlocked", currentLevel + 1);
            Debug.Log(PlayerPrefs.GetInt("LevelUnlocked"));
            SceneManager.LoadScene(0);
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteract : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("LevelUnlocked", PlayerPrefs.GetInt("LevelUnlocked"));
            SceneManager.LoadScene(0);
        }
    }
}

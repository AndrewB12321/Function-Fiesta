using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteract : MonoBehaviour
{
    public GameObject[] keys;
    bool open;
    private void Start()
    {
        keys = GameObject.FindGameObjectsWithTag("Key");
        open = false;
    }
    private void Update()
    {
        keys = GameObject.FindGameObjectsWithTag("Key");
        if(keys.Length == 0)
            open = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(open){
                int currentLevel = PlayerPrefs.GetInt("LevelUnlocked");

                if (currentLevel == 0)
                    PlayerPrefs.SetInt("LevelUnlocked", 1);

                PlayerPrefs.SetInt("LevelUnlocked", currentLevel + 1);
                Debug.Log(PlayerPrefs.GetInt("LevelUnlocked"));
                SceneManager.LoadScene(0);
            }
        }
    }
}

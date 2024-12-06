using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private bool isPaused = false;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void BackToGameButton()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void PauseButton()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            pauseMenu.SetActive(isPaused);
        }

        if(isPaused)
        {
            Time.timeScale = 0f;
        } 
        else
        {
            Time.timeScale = 1f;
        }
    }
}

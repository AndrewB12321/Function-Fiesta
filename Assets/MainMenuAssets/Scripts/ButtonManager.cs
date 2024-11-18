using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject frontMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject levelSelectMenu;

    private void Start()
    {
        frontMenu.SetActive(true);
        settingsMenu.SetActive(false);
        levelSelectMenu.SetActive(false);
    }

    public void LevelSelectButton()
    {
        frontMenu.SetActive(false);
        settingsMenu.SetActive(false);
        levelSelectMenu.SetActive(true);
    }

    public void SettingsButton()
    {
        frontMenu.SetActive(false);
        settingsMenu.SetActive(true);
        levelSelectMenu.SetActive(false);
    }

    public void BackButton()
    {
        frontMenu.SetActive(true);
        settingsMenu.SetActive(false);
        levelSelectMenu.SetActive(false);
    }

    public void LevelLoadButton(int level)
    {
        if(SceneManager.GetSceneByBuildIndex(level) != null )
        {
            SceneManager.LoadScene(level);
        }
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}

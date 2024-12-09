using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject frontMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject levelSelectMenu;
    [SerializeField] private GameObject creditsScreen;

    private void Start()
    {
        PlayerPrefs.SetInt("LevelUnlocked", 1);
        BackButton();
    }

    public void LevelSelectButton()
    {
        frontMenu.SetActive(false);
        settingsMenu.SetActive(false);
        levelSelectMenu.SetActive(true);
        creditsScreen.SetActive(false);
    }

    public void SettingsButton()
    {
        frontMenu.SetActive(false);
        settingsMenu.SetActive(true);
        levelSelectMenu.SetActive(false);
        creditsScreen.SetActive(false);
    }

    public void CreditsButton()
    {
        frontMenu.SetActive(false);
        settingsMenu.SetActive(false);
        levelSelectMenu.SetActive(false);
        creditsScreen.SetActive(true);
    }

    public void BackButton()
    {
        frontMenu.SetActive(true);
        settingsMenu.SetActive(false);
        levelSelectMenu.SetActive(false);
        creditsScreen.SetActive(false);
    }

    public void LevelLoadButton(int level)
    {
        if(SceneManager.GetSceneByBuildIndex(level) != null && PlayerPrefs.GetInt("LevelUnlocked") >= level)
        {
            SceneManager.LoadScene(level);
        }
    }

    public void QuitButton()
    {
        Debug.Log("Game Quit!");
        Application.Quit();
    }
}

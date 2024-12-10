using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject frontMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject levelSelectMenu;
    [SerializeField] private GameObject creditsScreen;

    [SerializeField] private GameObject level1;
    [SerializeField] private GameObject level2;
    [SerializeField] private GameObject level3;
    [SerializeField] private GameObject level4;
    [SerializeField] private GameObject level5;
    [SerializeField] private GameObject level6;

    private void Start()
    {
        BackButton();
    }

    private void Update()
    {
        Image level1Renderer = level1.GetComponent<Image>();
        Image level2Renderer = level2.GetComponent<Image>();
        Image level3Renderer = level3.GetComponent<Image>();
        Image level4Renderer = level4.GetComponent<Image>();
        Image level5Renderer = level5.GetComponent<Image>();
        Image level6Renderer = level6.GetComponent<Image>();

        level1Renderer.color = getColor(1, PlayerPrefs.GetInt("LevelUnlocked"));
        level2Renderer.color = getColor(2, PlayerPrefs.GetInt("LevelUnlocked"));
        level3Renderer.color = getColor(3, PlayerPrefs.GetInt("LevelUnlocked"));
        level4Renderer.color = getColor(4, PlayerPrefs.GetInt("LevelUnlocked"));
        level5Renderer.color = getColor(5, PlayerPrefs.GetInt("LevelUnlocked"));
        level6Renderer.color = getColor(6, PlayerPrefs.GetInt("LevelUnlocked"));
    }

    private Color getColor(int level, int playerLevel)
    {
        if(level > playerLevel)
        {
            return Color.red;
        }
        else
        {
            return Color.yellow;
        }
    }

    public void LevelSelectButton()
    {
        frontMenu.SetActive(false);
        settingsMenu.SetActive(false);
        levelSelectMenu.SetActive(true);
        creditsScreen.SetActive(false);
        PlayerPrefs.SetInt("levelUnlocked", 1);
        Debug.Log(PlayerPrefs.GetInt("levelUnlocked"));
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
        Debug.Log("LoadLevel Called!");
        if (SceneManager.GetSceneByBuildIndex(level) != null && PlayerPrefs.GetInt("LevelUnlocked") >= level)
        {
            Debug.Log("Level button: " + level + " clicked!");
            SceneManager.LoadScene(level);
        }
    }

    public void QuitButton()
    {
        Debug.Log("Game Quit!");
        Application.Quit();
    }
}

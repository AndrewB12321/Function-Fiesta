using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public Slider volumeSlider; // Reference to the volume slider
    public Button closeButton; // Reference to the close button
    public TextMeshProUGUI volumeValueText; // (Optional) Text to display volume value

    private void Start()
    {
        // Set initial volume based on saved settings or default value
        float savedVolume = PlayerPrefs.GetFloat("Volume", 0.5f); // Default to 50%
        volumeSlider.value = savedVolume;
        UpdateVolume(savedVolume);

        // Add listeners to UI elements
        volumeSlider.onValueChanged.AddListener(UpdateVolume);
        closeButton.onClick.AddListener(CloseSettings);
    }

    private void UpdateVolume(float value)
    {
        // Update the volume (you can integrate with your audio system here)
        AudioListener.volume = value;

        // Save the volume setting
        PlayerPrefs.SetFloat("Volume", value);

        // Update volume value text if used
        if (volumeValueText != null)
        {
            volumeValueText.text = $"Volume: {(int)(value * 100)}%";
        }
    }

    private void CloseSettings()
    {
        // Hide the settings menu (or deactivate the panel)
        gameObject.SetActive(false);
    }
}

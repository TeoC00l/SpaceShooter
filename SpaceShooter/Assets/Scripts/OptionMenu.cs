using System;
using UnityEngine;
using  UnityEngine.UI;
using UnityEngine.Audio;
using  TMPro;

public class OptionMenu : MonoBehaviour
{
    [SerializeField]
    private Slider musicVolumeSlider;
    [SerializeField]
    private Slider gameplayVolumeSlider;
    [SerializeField]
    private TMP_Dropdown qualitySettingsDropdown;
    [SerializeField]
    private AudioMixer musicAudioMixer;
    [SerializeField]
    private AudioMixer gameplayAudioMixer;

    [SerializeField]
    private Button returnButton;

    [SerializeField]
    private GameObject mainMenu;

    private void Awake()
    {
        musicVolumeSlider.onValueChanged.AddListener(ChangeMusicVolume);
        gameplayVolumeSlider.onValueChanged.AddListener(ChangeGameplayVolume);
        qualitySettingsDropdown.onValueChanged.AddListener(SetGraphicsQuality);
        returnButton.onClick.AddListener(HideOptionMenu);
    }

    private void ChangeMusicVolume(float volume)
    {
        musicAudioMixer.SetFloat("MusicVolume", volume);
    }
    private void ChangeGameplayVolume(float volume)
    {
        gameplayAudioMixer.SetFloat("MasterVolume", volume);
    }

    private void SetGraphicsQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    private void HideOptionMenu()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}

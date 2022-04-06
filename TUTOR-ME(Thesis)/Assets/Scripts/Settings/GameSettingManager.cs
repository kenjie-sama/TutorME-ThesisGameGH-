using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public class GameSettingManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown framerateDropdown, qualityDropdown;
    [SerializeField] private Slider slider_BGM, slider_SFX;
    [SerializeField] private AudioSource audio_BGM;
    [SerializeField] private AudioSource[] audio_SFX;
    [SerializeField] private GameSettingData gameSettingData;
    [SerializeField] private TextMeshProUGUI txt_bgm, txt_sfx;

    [SerializeField] private Button btn_saved, btn_back;
    
    private void Awake()
    {
        InitializeValues();
        InitializeListeners();
    }

    private void InitializeListeners()
    {
        btn_saved?.onClick.AddListener(() => SaveSettings());
        btn_back?.onClick.AddListener(() => ResetGameSetting());

        framerateDropdown.onValueChanged.AddListener((value) => gameSettingData.temp_framerate = value);
        qualityDropdown.onValueChanged.AddListener((value) => gameSettingData.temp_qualityLevel = value);
        
        slider_BGM.onValueChanged.AddListener((value) => {
            gameSettingData.temp_BGMVolume = (int) value;
      
            SetSliderText(txt_bgm, "Background Music Volume", gameSettingData.temp_BGMVolume);
            audio_BGM.volume = (float) gameSettingData.temp_BGMVolume  / 100;
        });
        
        slider_SFX.onValueChanged.AddListener((value) => {
            gameSettingData.temp_SFXVolume = (int) value;
            SetSliderText(txt_sfx, "Sound Effects Volume", gameSettingData.temp_SFXVolume);
            foreach (AudioSource sfx in audio_SFX)
                sfx.volume = (float) gameSettingData.temp_SFXVolume  / 100;
        });
    }

    private void InitializeValues()
    {
        gameSettingData.LoadPreferences();
        SetGameSetting(true);
        SetDropdownValue(framerateDropdown, gameSettingData.Framerate);
        SetDropdownValue(qualityDropdown, gameSettingData.QualityLevel);
    }

    private void SetDropdownValue(TMP_Dropdown dropdown, int _value) => dropdown.value = _value;
    private void SetSliderText(TextMeshProUGUI textHolder, string text, int value) => textHolder.text = string.Format(text + " ({0})", value);

    public void SetGameSetting(bool onAwake = false)
    {
        slider_BGM.value = gameSettingData.BackgroundMusicVolume;
        slider_SFX.value = gameSettingData.SoundfEffectsVolume;

        audio_BGM.volume = (float) gameSettingData.BackgroundMusicVolume / 100;

        foreach (AudioSource sfx in audio_SFX)
            sfx.volume = (float) gameSettingData.SoundfEffectsVolume  / 100;
        
        audio_BGM.enabled = gameSettingData.BackgroundMusicVolume > 0;
        foreach (AudioSource sfx in audio_SFX)
            sfx.enabled = gameSettingData.SoundfEffectsVolume > 0;
        
        switch (gameSettingData.Framerate)
        {
            case 0: Application.targetFrameRate = 24; break;
            case 1: Application.targetFrameRate = 45; break;
            case 2: Application.targetFrameRate = 60; break;
            default: Application.targetFrameRate = -1; break;
        }
        QualitySettings.SetQualityLevel(gameSettingData.QualityLevel);
        
        SetSliderText(txt_bgm, "Background Music Volume", gameSettingData.BackgroundMusicVolume);
        SetSliderText(txt_sfx, "Sound Effects Volume", gameSettingData.SoundfEffectsVolume);
    }
    
    private void ConfirmChanges()
    {
        if (!gameSettingData.IsChanged())
            return;
        // MainMenu.Instance.GotoMainMenu();
        ModalManager.Instance.ShowModal("Confirm Changes", "Apply Setting Configurations?",
            true, "Yes", true, "No", 
            SaveSettings, ResetGameSetting);
    }
    
    private void ResetGameSetting()
    {
        gameSettingData.ResetChanges();
        
        SetDropdownValue(framerateDropdown, gameSettingData.temp_framerate);
        SetDropdownValue(qualityDropdown, gameSettingData.temp_qualityLevel);
        
        slider_BGM.value = gameSettingData.temp_BGMVolume;
        slider_SFX.value = gameSettingData.temp_SFXVolume;
        
        SetSliderText(txt_bgm, "Background Music Volume", gameSettingData.temp_BGMVolume);
        SetSliderText(txt_sfx, "Sound Effects Volume", gameSettingData.temp_SFXVolume);
        
        
        MainMenu.Instance.GotoMainMenu();

    }
    
    private void SaveSettings()
    {
        gameSettingData.SavePreferences();
        gameSettingData.UpdateChanges();

        SetGameSetting();
        MainMenu.Instance.GotoMainMenu();

    }
}

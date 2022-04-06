using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "SettingsData", menuName = "Game Settings")]
public class GameSettingData : ScriptableObject
{        
    [SerializeField] private int m_framerate = 4, m_qualityLevel = 2;
    [SerializeField, Range(0, 100)] private int m_BGMVolume = 40, m_SFXVolume = 60;
    [SerializeField] private bool anyChanges = false;

    [Space, Header("Temporary Fields")] 
    public int temp_framerate;
    public int temp_qualityLevel, temp_BGMVolume, temp_SFXVolume;
    
    public int Framerate
    {
        get => m_framerate;
        set => m_framerate = value;
    }

    public int QualityLevel
    {
        get => m_qualityLevel;
        set => m_qualityLevel = value;
    }

    public int BackgroundMusicVolume
    {
        get => m_BGMVolume;
        set => m_BGMVolume = value;
    }

    public int SoundfEffectsVolume
    {
        get => m_SFXVolume;
        set => m_SFXVolume = value;
    }

    public void LoadPreferences()
    {
        Framerate = PlayerPrefs.GetInt("player_Framerate", 4);
        QualityLevel = PlayerPrefs.GetInt("player_QualityLevel", 3);
        BackgroundMusicVolume = PlayerPrefs.GetInt("player_BackgroundMusicVolume", 35);
        SoundfEffectsVolume = PlayerPrefs.GetInt("player_SoundEffectsVolume", 45);
        ResetChanges();
    }
    
    public void SavePreferences()
    {
        PlayerPrefs.SetInt("player_Framerate", temp_framerate);
        PlayerPrefs.SetInt("player_QualityLevel", temp_qualityLevel);
        PlayerPrefs.SetInt("player_BackgroundMusicVolume", temp_BGMVolume);
        PlayerPrefs.SetInt("player_SoundEffectsVolume", temp_SFXVolume);
        PlayerPrefs.Save();
        
        UpdateChanges();
        
        Debug.Log("Saved FPS: " + temp_framerate);
        Debug.Log("Saved Qual: " + temp_qualityLevel);
        Debug.Log("Saved BGM: " + temp_BGMVolume);
        Debug.Log("Saved SFX: " + temp_SFXVolume);

    }

    public void ResetChanges()
    {
        temp_framerate = Framerate;
        temp_qualityLevel = QualityLevel;
        temp_BGMVolume = BackgroundMusicVolume;
        temp_SFXVolume = SoundfEffectsVolume;
    }

    public void UpdateChanges()
    {
        Framerate = temp_framerate;
        QualityLevel = temp_qualityLevel;
        BackgroundMusicVolume = temp_BGMVolume;
        SoundfEffectsVolume = temp_SFXVolume;
    }
    public bool IsChanged()
    {
        bool anyChanges = false;
        if (temp_framerate != Framerate) 
            anyChanges = true;
        else if (temp_qualityLevel != QualityLevel)
            anyChanges = true;
        else if (temp_BGMVolume != BackgroundMusicVolume)
            anyChanges = true;
        else if (temp_SFXVolume != SoundfEffectsVolume)
            anyChanges = true;
        this.anyChanges = anyChanges;
        return this.anyChanges ;
    }
}

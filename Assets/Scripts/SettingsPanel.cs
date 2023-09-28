using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MovePanel
{
    [SerializeField] private Slider _musicSlider = null;
    [SerializeField] private Slider _soundSlider = null;
    [SerializeField] private Button _clousedButton = null;

    public void SetMusicVolume(float value)
    {
        AudioController.SetMusicVolume(value);
    }
    public void SetSoundsVolume(float value)
    {
        AudioController.SetSoundVolume(value);
    }
    private void OnEnable()
    {
        _musicSlider.onValueChanged.AddListener(SetMusicVolume);
        _soundSlider.onValueChanged.AddListener(SetSoundsVolume);
        _clousedButton.onClick.AddListener(HidePanel);

    }
    private void OnDisable()
    {
        _musicSlider.onValueChanged.RemoveListener(SetMusicVolume);
        _soundSlider.onValueChanged.RemoveListener(SetSoundsVolume);
        _clousedButton.onClick.RemoveListener(HidePanel);
    }
}

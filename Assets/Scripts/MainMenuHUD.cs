using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuHUD : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton = null;
    [SerializeField] private Button _exitButton = null;
    [SerializeField] private MovePanel _movePanel = null;
    [SerializeField] private int _gameIndex = 2;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(LoadScene);
        _settingsButton.onClick.AddListener(ShowSettingsPanel);
        _exitButton.onClick.AddListener(Exit);

    }
    private void OnDisable()
    {
        _settingsButton.onClick.RemoveListener(ShowSettingsPanel);
        _exitButton.onClick.RemoveListener(Exit);
        _playButton.onClick.RemoveListener(LoadScene);

    }
    private void LoadScene()
    {
        SceneManager.LoadScene(_gameIndex);
    }

    public void ShowSettingsPanel()
    {
        _movePanel.ShowPanel();
    }
    public void Exit()
    {
        Application.Quit();
    }
}

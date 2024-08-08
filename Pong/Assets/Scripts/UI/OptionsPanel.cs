using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OptionsPanel : Window
{
    [SerializeField] Slider _soundSlider;
    [SerializeField] Slider _musicSlider;
    [SerializeField] Button _backButton;
    public static Action BackFromSettingsClick;

    private void Start()
    {
        _backButton.onClick.AddListener(CloseWindow);
    }

    private void OnDestroy()
    {
        _backButton.onClick.RemoveListener(CloseWindow);
    }
}

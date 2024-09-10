using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OptionsPanel : Window
{
    [SerializeField] Slider _soundSlider;
    [SerializeField] Slider _musicSlider;
    [SerializeField] Button _backButton;
    [SerializeField] EventSystem _eventSystem;

    private void Start()
    {
        _eventSystem.SetSelectedGameObject(_backButton.gameObject);
    }

    private void OnEnable()
    {
        _backButton.onClick.AddListener(CloseWindow);
    }

    private void OnDisable()
    {
        _backButton.onClick.RemoveListener(CloseWindow);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OptionsPanel : Window
{
    [SerializeField] Slider m_soundSlider;
    [SerializeField] Slider m_musicSlider;
    [SerializeField] Button m_backButton;
    public static Action BackFromSettingsClick;

    protected override void OnEnable()
    {
        base.OnEnable();
        m_backButton.onClick.AddListener(OnBackButtonClick);
        _playerInputActions.UI.Cancel.performed += OnBackButtonPressed;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        m_backButton.onClick.RemoveListener(OnBackButtonClick);
        _playerInputActions.UI.Cancel.performed -= OnBackButtonPressed;
    }
    
    private void OnBackButtonClick()
    {
        BackFromSettingsClick?.Invoke();
        ClosePanel();
    }
    
    private void OnBackButtonPressed(InputAction.CallbackContext context)
    {
        BackFromSettingsClick?.Invoke();
        ClosePanel();
    }
}

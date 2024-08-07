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

    private void Start()
    {
        m_backButton.onClick.AddListener(ClosePanel);
    }

    private void OnDestroy()
    {
        m_backButton.onClick.RemoveListener(ClosePanel);
    }
    
    
    /*
    private void OnBackButtonPressed(InputAction.CallbackContext context)
    {
        BackFromSettingsClick?.Invoke();
        ClosePanel();
    }
    */
}

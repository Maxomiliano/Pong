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

    private void OnEnable()
    {
        _eventSystem.SetSelectedGameObject(_soundSlider.gameObject);
        _backButton.onClick.AddListener(CloseWindow);
    }

    private void OnDisable()
    {
        _backButton.onClick.RemoveListener(CloseWindow);
    }

    public override void CloseWindow()
    {
        DeselectCurrentButton();
        base.CloseWindow();
    }
    private void DeselectCurrentButton()
    {
        SelectableArrow arrowComponent = _backButton.GetComponent<SelectableArrow>();
        if (arrowComponent != null)
        {
            arrowComponent.HideArrow();
        }
        _eventSystem.SetSelectedGameObject(_soundSlider.gameObject);
    }
}

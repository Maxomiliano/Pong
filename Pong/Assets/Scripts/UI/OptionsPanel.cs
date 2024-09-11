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
        // Antes de cerrar, deselecciona el objeto actual y oculta flechas
        DeselectCurrentButton();
        base.CloseWindow(); // Llama al método base para cerrar la ventana
    }
    private void DeselectCurrentButton()
    {
        // Desactivar flecha del botón de "Back"
        SelectableArrow arrowComponent = _backButton.GetComponent<SelectableArrow>();
        if (arrowComponent != null)
        {
            arrowComponent.HideArrow();
        }

        // Deseleccionar el objeto actual del EventSystem
        _eventSystem.SetSelectedGameObject(_soundSlider.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExitPanel : Window
{
    [SerializeField] Button _yesButton;
    [SerializeField] Button _noButton;
    [SerializeField] EventSystem _eventSystem;
    private void OnEnable()
    {
        _yesButton.onClick.AddListener(Application.Quit);
        _noButton.onClick.AddListener(CloseWindow);
        _eventSystem.SetSelectedGameObject(_noButton.gameObject);
    }
    private void OnDisable()
    {
        _yesButton.onClick.RemoveListener(Application.Quit);
        _noButton.onClick.RemoveListener(CloseWindow);
    }
    public override void CloseWindow()
    {
        // Antes de cerrar, deselecciona el objeto actual y oculta flechas
        DeselectCurrentButton();
        base.CloseWindow(); // Llama al método base para cerrar la ventana
    }
    private void DeselectCurrentButton()
    {
        // Desactivar flecha del botón de back
        SelectableArrow arrowComponent = _yesButton.GetComponent<SelectableArrow>();
        if (arrowComponent != null)
        {
            arrowComponent.HideArrow();
        }

        // Dejo seleccionado el primer objeto del panel
        _eventSystem.SetSelectedGameObject(_noButton.gameObject);
    }
}

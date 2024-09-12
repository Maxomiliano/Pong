using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreditsPanel : Window
{
    [SerializeField] EventSystem _eventSystem;
    [SerializeField] Button _backButton;

    private void OnEnable()
    {
        _backButton.onClick.AddListener(CloseWindow);
        _eventSystem.SetSelectedGameObject(_backButton.gameObject);
    }

    private void OnDisable()
    {
        _backButton.onClick.RemoveListener(CloseWindow);
    }
}

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
}

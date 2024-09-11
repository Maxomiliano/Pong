using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitPanel : Window
{
    [SerializeField] Button _yesButton;
    [SerializeField] Button _noButton;
    private void OnEnable()
    {
        _yesButton.onClick.AddListener(Application.Quit);
        _noButton.onClick.AddListener(CloseWindow);
    }
    private void OnDisable()
    {
        _yesButton.onClick.RemoveListener(Application.Quit);
        _noButton.onClick.RemoveListener(CloseWindow);
    }
}

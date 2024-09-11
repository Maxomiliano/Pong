using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] Window _entryPointWindow;
    private PlayerInputActions _playerInputActions;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.UI.Pause.performed += OnPausePressed;
        _playerInputActions.UI.Cancel.performed += OnPausePressed;
    }

    private void OnEnable()
    {
        _playerInputActions.UI.Enable();
    }
    private void OnDisable()
    {
        _playerInputActions.UI.Disable();
    }

    private void OnPausePressed(InputAction.CallbackContext context)
    {
        Window currentPanel = WindowsManager.Instance.GetCurrentPanel();
        if (currentPanel != null)
        {
            if (currentPanel.IsCloseable)
            { 
                currentPanel.CloseWindow();
            }
        }
        else
        {
            if (_entryPointWindow != null)
                _entryPointWindow.OpenWindow();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] GameObject _pausePanel;
    private PlayerInputActions _playerInputActions;
    bool _isPausePanelOpen = false;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.UI.Pause.performed += OnPausePressed;
        _playerInputActions.UI.Cancel.performed += OnCancelPressed;
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
        if (!_pausePanel.activeInHierarchy)
        {
            _pausePanel.GetComponent<PausePanel>().OpenWindow();
            _isPausePanelOpen = true;
        }
        else
        {
            _pausePanel.GetComponent<PausePanel>().CloseWindow();
            _isPausePanelOpen = false;
        }
    }
    
    private void OnCancelPressed(InputAction.CallbackContext context)
    {  
        if (_isPausePanelOpen)
        {
            return;
        }
        else
        {
            WindowsManager.Instance.PopWindow();
        }
    }
}

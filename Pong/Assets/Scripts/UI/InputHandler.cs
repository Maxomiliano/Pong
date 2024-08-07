using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] GameObject m_pausePanel;
    private PlayerInputActions _playerInputActions;

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
        //Window currentWindow = WindowsManager.Instance.GetCurrentPanel();
        if (m_pausePanel.gameObject.activeInHierarchy)
        {
            m_pausePanel.GetComponent<PausePanel>().ClosePanel();
        }
        else
        {
            /*
            PausePanel pauseWindow = m_pausePanel.GetComponent<PausePanel>();
            if(pauseWindow != null) 
            {
                pauseWindow.OpenPanel();
            }
            */
            m_pausePanel.GetComponentInChildren<PausePanel>().OpenPanel();
        }
    }
    private void OnCancelPressed(InputAction.CallbackContext context)
    {
        if (m_pausePanel.activeInHierarchy)
        {
            m_pausePanel.GetComponent<PausePanel>().ClosePanel();
        }
        else
        {
            WindowsManager.Instance.PopWindow();
        }
    }
}

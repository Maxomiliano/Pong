using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Window : MonoBehaviour
{
    protected PlayerInputActions _playerInputActions;

    protected virtual void Awake()
    {
        _playerInputActions = new PlayerInputActions();
    }
    protected virtual void OnEnable()
    {
        _playerInputActions.UI.Enable();
    }
    protected virtual void OnDisable()
    {
        _playerInputActions.UI.Disable();
    }

    public virtual void OpenPanel()
    {
        WindowsManager.Instance.PushWindow(this);
        gameObject.SetActive(true);
    }

    public virtual void ClosePanel() 
    {
        WindowsManager.Instance.PopWindow();
        gameObject.SetActive(false);
    }
}

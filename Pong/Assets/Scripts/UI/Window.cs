using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField] MainMenu _mainMenu;
    [SerializeField] PausePanel _pausePanel;
    public bool IsCloseable = true;

    public virtual void OpenWindow()
    {
        WindowsManager.Instance.PushWindow(this);
        gameObject.SetActive(true);
        SFXController.Instance.PlayPopupOpensSFX();
        WindowsManager.Instance.UpdateTimeScale();
    }

    public virtual void CloseWindow() 
    {
        WindowsManager.Instance.PopWindow();
        gameObject.SetActive(false);
        WindowsManager.Instance.UpdateTimeScale();
        SFXController.Instance.PlayPopupOpensSFX();

        if (_mainMenu != null)
        {
            _mainMenu.SelectFirstMenuItem();
        }
        Debug.Log(Time.timeScale);
    }
}

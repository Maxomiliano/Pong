using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Window : MonoBehaviour
{
    public virtual void OpenPanel()
    {
        WindowsManager.Instance.PushWindow(this);
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public virtual void ClosePanel() 
    {
        WindowsManager.Instance.PopWindow();
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}

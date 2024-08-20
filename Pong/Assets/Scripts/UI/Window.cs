using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    public bool IsCloseable = true;
    public virtual void OpenWindow()
    {
        WindowsManager.Instance.PushWindow(this);
        gameObject.SetActive(true);
        Time.timeScale = 0; //cambiar esto de lugae
    }

    public virtual void CloseWindow() 
    {
        WindowsManager.Instance.PopWindow();
        gameObject.SetActive(false);
        Time.timeScale = 1; //esto tambien
    }
}

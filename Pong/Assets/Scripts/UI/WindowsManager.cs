using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    public static WindowsManager Instance { get; private set; }
    private Stack<Window> _windowsStack = new Stack<Window>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PushWindow(Window window)
    {
        
        if (_windowsStack.Count > 0)
        {
            _windowsStack.Peek().gameObject.SetActive(false);
        }
        
        _windowsStack.Push(window);
        Debug.Log("Opened window: " + window.name);
    }

    public void PopWindow()
    {
        if (_windowsStack.Count == 0) return;
        Window topWindow = _windowsStack.Pop();
        topWindow.gameObject.SetActive(false);
        Debug.Log("Closed window: " + topWindow.name);
        if (_windowsStack.Count > 0)
        {
            _windowsStack.Peek().gameObject.SetActive(true);
            Debug.Log("Current top panel: " + _windowsStack.Peek().name);
        }
    }

    public Window GetCurrentPanel()
    {
        return _windowsStack.Count > 0 ? _windowsStack.Peek() : null;
    }

    public void UpdateTimeScale()
    {
        // Si no hay ventanas en la pila, reanuda el juego
        if (_windowsStack.Count == 0)
        {
            Time.timeScale = 1;
            return;
        }

        // Pausa el juego si alguna ventana requiere que el juego esté pausado
        Time.timeScale = 0;
    }
}

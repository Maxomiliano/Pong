using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryPanel : MonoBehaviour
{
    [SerializeField] GameObject[] m_stars;
    [SerializeField] GameObject m_badges;
    [SerializeField] Button m_mainMenuButton;

    public Action<bool> OnVictoryViewStateChanged;
    public Action OnVictoryPanelShowed;
   

    void Start()
    {
        gameObject.SetActive(false);
        m_mainMenuButton.onClick.AddListener(GameController.Instance.GoToMainMenuFromVictoryPanel);
        //m_mainMenuButton.onClick.AddListener(() => SFXController.Instance.PlayButtonPressSFX());
    }

    public void ShowVictoryPanel()
    {

            //MusicController.Instance.SetVictoryPanelTheme();
            OnVictoryViewStateChanged?.Invoke(true);
            gameObject.SetActive(true);
            m_mainMenuButton.gameObject.SetActive(true);
            //SFXController.Instance.PlayPopupOpensSFX();
            OnVictoryPanelShowed?.Invoke();
    }
}

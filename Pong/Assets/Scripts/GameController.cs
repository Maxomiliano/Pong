using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    const float MIXER_MIN_VALUE = -80;
    public static GameController m_instance;
    public static GameController Instance { get => m_instance; }
    [SerializeField] public Ball _ball;
    [SerializeField] public PlayerScore _playerScore;
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private PlayerMovement _player2Movement;
    [SerializeField] private TestAIMovement _player2AIMovement;
    [SerializeField] private UITimer _timer;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private SaveData m_saveData;
    public static Action OnGoToMainMenu;
    [SerializeField] VictoryPanel _victoryPanel;

    public float MusicValue
    {
        get => m_saveData.MusicValue;
        set
        {
            m_saveData.MusicValue = value;
            SaveData();
        }
    }
    public float SFXValue
    {
        get => m_saveData.SFXValue;
        set
        {
            m_saveData.SFXValue = value;
            SaveData();
        }
    }

    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        _canvas.gameObject.SetActive(false);    
    }

    private void OnEnable()
    {
        _playerScore.onPointScored += OnPointScored;
    }

    void Start()
    {
        StartCoroutine(_timer.Countdown());
        StartCoroutine(ShowCanvasCoroutine());
        SetGameMode();     
    }

    private IEnumerator ShowCanvasCoroutine()
    {
        yield return new WaitForSeconds(.1f);
        _canvas.gameObject.SetActive(true);
    }

    private void SetGameMode()
    {
        if (_gameSettings.IsPVP)
        {
            _player2Movement.enabled = true;
            _player2AIMovement.enabled = false;
            return;
        }

        _player2Movement.enabled = false;
        _player2AIMovement.enabled = true;
    }

    private void ResetGame(PlayerType playerType)
    {
        _ball.transform.position = new Vector2(0, 0);
        _ball.GoToRandomPosition(playerType);
    }

    private void OnPointScored(PlayerType playerType)
    {
        ResetGame(playerType);
    }

    public static void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        OnGoToMainMenu?.Invoke();
    }

    public void GoToMainMenuFromVictoryPanel()
    {
        //SaveData();
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        OnGoToMainMenu?.Invoke();
    }
    
    public void SaveData()
    {

        float musicValue = Mathf.Log10(m_saveData.MusicValue) * 20;
        if (musicValue == -Mathf.Infinity) musicValue = MIXER_MIN_VALUE;
        float sfxValue = Mathf.Log10(m_saveData.SFXValue) * 20;
        if (sfxValue == -Mathf.Infinity) sfxValue = MIXER_MIN_VALUE;

        //m_audioMixer.SetFloat("MusicAmmount", musicValue);
        //m_audioMixer.SetFloat("SFXAmmount", sfxValue);
    }
    

    private void OnDisable()
    {
        _playerScore.onPointScored -= OnPointScored;
    }

    public void PlayerWon(string playerID)
    {
        _victoryPanel.ShowVictoryPanel(playerID);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class AudioController : MonoBehaviour
{
    public static AudioController m_instance;
    public static AudioController Instance { get => m_instance; }
    public const int MAX_LEVEL = 9;
    const float MIXER_MIN_VALUE = -80;
    [SerializeField] private SaveData m_saveData;
    [SerializeField] private AudioMixer m_audioMixer;
    
    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

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

    public void SaveData()
    {
        float musicValue = Mathf.Log10(m_saveData.MusicValue) * 20;
        if (musicValue == -Mathf.Infinity) musicValue = MIXER_MIN_VALUE;
        float sfxValue = Mathf.Log10(m_saveData.SFXValue) * 20;
        if (sfxValue == -Mathf.Infinity) sfxValue = MIXER_MIN_VALUE;

        m_audioMixer.SetFloat("MusicAmmount", musicValue);
        m_audioMixer.SetFloat("SFXAmmount", sfxValue);
    }
    public void SetSaveData(SaveData data)
    {
        m_saveData = data == null ? new() : data;
        SaveData();
    }
}

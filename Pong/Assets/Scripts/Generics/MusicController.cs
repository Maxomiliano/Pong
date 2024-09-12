using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : NullableSingleton<MusicController>

{
    [SerializeField] MusicClip[] m_tracks;
    [SerializeField] AudioSource[] m_sources;
    private Dictionary<string, MusicClip> m_lookupMusic;
    private int m_activeSourceIndex = 0;
    private double nextEventTime;
    private bool running;

    MusicClip m_currentClip = null;
    MusicClip m_nextClip = null;

    private bool m_firstTimeOnMainMenu = true;


    private void Start()
    {
        m_lookupMusic = m_tracks.ToDictionary(item => item.ID, item => item);
        SceneManager.sceneLoaded += SetMusicClip;
        nextEventTime = AudioSettings.dspTime + 2.0f;
        running = true;
        foreach (var item in m_sources)
        {
            item.loop = false;
        }
        m_nextClip = m_lookupMusic["pixel_intro"];
    }

    private void SetMusicClip(Scene scene, LoadSceneMode sceneMode)
    {
        switch (scene.name)
        {
            case "MainMenu":
                if (!m_firstTimeOnMainMenu)
                    CrossfadeTo("pixel_intro");
                break;
            default:
                CrossfadeTo("pixel_intro");
                break;
        }
    }

    private void Update()
    {
        if (!running)
            return;

        double time = AudioSettings.dspTime;

        if (time + 1.0f > nextEventTime)
        {
            m_currentClip = m_nextClip;
            AudioSource audioSource = m_sources[m_activeSourceIndex];
            audioSource.clip = m_currentClip.Clip;
            audioSource.PlayScheduled(nextEventTime);

            nextEventTime += m_currentClip.ClipLength;
            m_activeSourceIndex = 1 - m_activeSourceIndex;
            if (!m_currentClip.Loop) m_nextClip = m_lookupMusic[m_currentClip.NextClip];
            else m_nextClip = m_currentClip;

            Debug.Log("Scheduled source " + m_activeSourceIndex + " to start at time " + nextEventTime);
        }
    }

    private void CrossfadeTo(string clip)
    {
        m_currentClip = m_lookupMusic[clip];
        m_nextClip = null;
        nextEventTime = AudioSettings.dspTime + 0.5;

        AudioSource audioSource = m_sources[m_activeSourceIndex];
        audioSource.clip = m_lookupMusic[clip].Clip;
        audioSource.PlayScheduled(nextEventTime);

        m_activeSourceIndex = 1 - m_activeSourceIndex;
        nextEventTime += m_currentClip.ClipLength;
        if (!m_currentClip.Loop) m_nextClip = m_lookupMusic[m_currentClip.NextClip];
        else m_nextClip = m_currentClip;

        StartCoroutine(Crossfade(audioSource, m_sources[m_activeSourceIndex], 2.0f, 0.5f));
    }

    public void LinkAtBeatTo(string clip)
    {
        var currentBPM = m_currentClip.BPMInSecons;
        m_currentClip = m_lookupMusic[clip];
        m_nextClip = null;
        double timeWindow = nextEventTime - AudioSettings.dspTime;
        int availableBeats = (int)(timeWindow / currentBPM);
        nextEventTime = nextEventTime - (availableBeats * currentBPM);
        if (nextEventTime < 0.5) nextEventTime += currentBPM;

        AudioSource audioSource = m_sources[m_activeSourceIndex];
        audioSource.clip = m_lookupMusic[clip].Clip;
        audioSource.PlayScheduled(nextEventTime);
        m_activeSourceIndex = 1 - m_activeSourceIndex;
        m_sources[m_activeSourceIndex].SetScheduledEndTime(nextEventTime);
        Debug.Log("Scheduled source " + m_activeSourceIndex + " to start at time " + nextEventTime);
        nextEventTime = double.PositiveInfinity;

    }

    IEnumerator Crossfade(AudioSource inAudioSource, AudioSource outAudioSource, float duration, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        outAudioSource.volume = 0;
        float eTime = 0;
        while (eTime < duration)
        {
            inAudioSource.volume = eTime / duration;
            outAudioSource.volume = 1 - (eTime / duration);
            eTime += Time.deltaTime;
            yield return null;
        }
        inAudioSource.volume = 1;

        outAudioSource.Stop();
        outAudioSource.volume = 1;
    }

    public void SetTreasureTheme()
    {
        m_nextClip = m_lookupMusic["gp_treasure_intro"];
    }

    public void SetVictoryTheme()
    {
        LinkAtBeatTo("gp_victory");
    }

    public void SetLooseTheme()
    {
        LinkAtBeatTo("gp_loose");
    }

    public void SetVictoryPanelTheme()
    {
        nextEventTime = AudioSettings.dspTime + 1.0f;
        m_nextClip = m_lookupMusic["gp_vv_intro"];
    }

    public void SetMaintheme()
    {
        CrossfadeTo("gp_intro");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : NullableSingleton<SFXController>
{
    [SerializeField] AudioClip[] m_uiButtonInteractionClips;
    [SerializeField] AudioClip[] m_popupOpenClips;
    //[SerializeField] AudioClip[] m_keyboardButtonPressClips;
    [SerializeField] AudioSource m_auso;

    public void PlayButtonPressSFX()
    {
        m_auso.PlayOneShot(m_uiButtonInteractionClips[Random.Range(0, m_uiButtonInteractionClips.Length)]);
    }

    public void PlayPopupOpensSFX()
    {
        m_auso.PlayOneShot(m_popupOpenClips[Random.Range(0, m_popupOpenClips.Length)]);
    }

    /*
    public void PlayKeyboardButtonPressSFX()
    {
        m_auso.PlayOneShot(m_keyboardButtonPressClips[Random.Range(0, m_keyboardButtonPressClips.Length)]);
    }

    public void TriggerParrotSound()
    {
        m_auso.PlayOneShot(m_keyboardButtonPressClips[Random.Range(0, m_keyboardButtonPressClips.Length)]);
    }
    */
}

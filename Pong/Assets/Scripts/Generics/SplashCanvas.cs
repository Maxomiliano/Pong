using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashCanvas : MonoBehaviour
{
    [SerializeField] private Image m_image;
    [SerializeField] private float m_fadeDuration = 3.0f;
    [SerializeField] private float m_stayDuration = 2.0f;

    void Start()
    {
        m_image.color = new Color(1, 1, 1, 0);

        Sequence sequence = DOTween.Sequence();
        sequence.Append(m_image.DOFade(1, m_fadeDuration))
                .AppendInterval(m_stayDuration)
                .Append(m_image.DOFade(0, m_fadeDuration))
                .OnComplete(() =>
                    SceneManager.LoadScene("MainMenu")
                );
    }
}
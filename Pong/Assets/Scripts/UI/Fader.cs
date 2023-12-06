using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pilgrims.Generics;

namespace TD.UI
{
    public class Fader : NullableSingleton<Fader>
    {
        [SerializeField] private CanvasGroup m_fader;

        private void Awake()
        {
            base.OnAwake();
            DontDestroyOnLoad(this.gameObject);
        }

        public void FadeOut(float duration = 1, Action callback = null)
        {
            m_fader.DOFade(1f, duration).OnComplete(() =>
            {
                m_fader.interactable = true;
                m_fader.blocksRaycasts = true;
                callback?.Invoke();
            });
        }

        public void FadeIn(float duration = 1, Action callback = null)
        {
            m_fader.DOFade(0f, duration).OnComplete(() =>
            {
                m_fader.interactable = false;
                m_fader.blocksRaycasts = false;
                callback?.Invoke();
            });
        }
    }
}
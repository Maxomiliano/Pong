using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TD.UI
{
    public class SplashScreenFade : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _splashCanvasGroup;

        private Tween _fadeTween;
        private Sequence _startSequence;


        private void Start()
        {
            _startSequence = DOTween.Sequence();                // Grab a free Sequence to use        
            _startSequence.Append(_splashCanvasGroup.DOFade(1, 2f));
            _startSequence.PrependInterval(2f);                // Delay the whole Sequence by 2 second
            _startSequence.Append(_splashCanvasGroup.DOFade(0, 2f));
            _startSequence.OnComplete(delegate
            {
                Fader.Instance.FadeOut(2f,
                    () => SceneManager.LoadScene("MainMenu"));
            }
            );
        }

        private void Fade(float endValue, float duration, TweenCallback onEnd)
        {
            if (_fadeTween != null)
            {
                _fadeTween.Kill(false);
            }

            _fadeTween = _splashCanvasGroup.DOFade(endValue, duration);
            _fadeTween.onComplete += onEnd;
        }

        public void FadeIn(float duration)
        {
            Fade(1f, duration, () =>
            {
                _splashCanvasGroup.interactable = true; //At the end of the Fade function this will aply
                _splashCanvasGroup.blocksRaycasts = true;
            });
        }

        public void FadeOut(float duration)
        {
            Fade(0f, duration, () =>
            {
                _splashCanvasGroup.interactable = false;
                _splashCanvasGroup.blocksRaycasts = false;
            });
        }



    }
}

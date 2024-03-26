using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _timerText;
    float _countdownTime = 3f;

    public IEnumerator Countdown()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1f);
        while (_countdownTime > 0) 
        {
            _timerText.text = _countdownTime.ToString();
            yield return new WaitForSecondsRealtime(1f);
            _countdownTime--;
        }
        _timerText.text = "GO!";
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1f;
        gameObject.SetActive(false);      
    }
}

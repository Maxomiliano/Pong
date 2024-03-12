using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableArrow : MonoBehaviour
{
    [SerializeField] GameObject _playButton;
    [SerializeField] GameObject _optionsButton;
    [SerializeField] GameObject _creditsButton;
    [SerializeField] GameObject _exitButton;
    [SerializeField] GameObject _arrowButton;

    private void Start()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.Select;
        entry.callback.AddListener((data) => { OnButtonSelected((PointerEventData)data); });
        trigger.triggers.Add(entry);
    }
    private void OnButtonSelected(PointerEventData data)
    {
        _arrowButton.SetActive(true);
    }
}

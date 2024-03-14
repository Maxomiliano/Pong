using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectableArrow : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    //[SerializeField] GameObject _button;
    [SerializeField] GameObject _arrow;

    /*
    private void Start()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.Select;
        entry.callback.AddListener((data) => { OnButtonSelected((PointerEventData)data); });
        trigger.triggers.Add(entry);
       
    }
    */

    private void OnButtonSelected(PointerEventData data)
    {
        
    }

    public void OnSelect(BaseEventData eventData)
    {
        _arrow.SetActive(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        _arrow.SetActive(false);
    }
}

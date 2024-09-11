using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectableArrow : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField] GameObject _arrow;

    public void OnSelect(BaseEventData eventData)
    {
        _arrow.SetActive(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        _arrow.SetActive(false);
    }

    public void HideArrow()
    {
        _arrow.SetActive(false); 
    }
}

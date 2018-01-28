using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

    public class ControlsButton : MonoBehaviour, ISelectHandler, IDeselectHandler// required interface when using the OnSelect method.
{
    public GameObject symbol;
    public GameObject text;
    //Do this when the selectable UI object is selected.
    public void OnSelect(BaseEventData eventData)
        {
        text.SetActive(true);
        }

    public void OnDeselect(BaseEventData eventData)
    {
        text.SetActive(false);
    }
}

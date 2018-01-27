using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExitButton : MonoBehaviour, ISelectHandler// required interface when using the OnSelect method.
{
    public GameObject exitSymbol;
    //Do this when the selectable UI object is selected.
    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("sono illuminato");
    }
}

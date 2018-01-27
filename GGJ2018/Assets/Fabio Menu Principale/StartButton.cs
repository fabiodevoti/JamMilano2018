using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

    public class StartButton : MonoBehaviour, ISelectHandler// required interface when using the OnSelect method.
    {
    public GameObject startSymbol;
        //Do this when the selectable UI object is selected.
        public void OnSelect(BaseEventData eventData)
        {
        Debug.Log("sono illuminato");
        }
    }

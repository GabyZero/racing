using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script to add to a button to permit to click it from an event
 **/
[RequireComponent(typeof(UnityEngine.UI.Button))]
public class ButtonClicker : MonoBehaviour
{
    
    public void Click()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
    }
}

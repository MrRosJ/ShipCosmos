using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateConsole : MonoBehaviour {

    public int TouchCounts;
    public bool isActiveConsole = false;
    public bool isActive = false;

    private void Update()
    {
        if(Input.touchCount > 0 && Input.touchCount < 2 && !isActive)
        {
            TouchCounts++;
        }

        if(TouchCounts > 100)
        {
            isActiveConsole = true;
            TouchCounts = 0;
            isActive = true;
        }
    }
}

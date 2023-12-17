using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomEvent : MonoBehaviour
{
    private delegate (int, int) CustomEventDelegate(string signalName, int occurence);

    //private CustomEventDelegate _customEventDelegate;
    private Action<string, int> _customActionDelegate; // Mettre void
    private Func< string, float, int> _customFuncDelegate;
    
    void Start()
    {
       // _customActionDelegate += SignalCallback;
        _customFuncDelegate += FuncCallaback;
      
        StartCoroutine(WaitForSignalCouroutine());

        IEnumerator WaitForSignalCouroutine()
        {
            yield return new WaitForSeconds(2);
            _customActionDelegate("Jean", 1);

            yield return new WaitForSeconds(1);
            int funactionValue = _customFuncDelegate("Michel", .1f);
        }
    }

    private void SignalCallback(string signalName, int occurence)
    {
        Debug.Log("Signal Receive");
    }

    private int FuncCallaback(string name, float value)
    {
        return 0;
    }
}

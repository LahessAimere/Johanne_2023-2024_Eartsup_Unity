using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class SignalReceiver : MonoBehaviour
{
    [SerializeField] private SignalEmitter _emitter;
    
    
    // Start is called before the first frame update
    void Start()
    {
       // string signalEmitter = nameof(SignalEmitter);
       // _emitter = GetComponent <SignalEmitter>();
        _emitter.Signal += TestSignal;
    }

    private void TestSignal()
    {
        Debug.Log("Signal Received from Emitter");
    }
}

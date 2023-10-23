using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(0)]
public class SignalEmitter : MonoBehaviour
{
    public Action Signal;
    
    // Start is called before the first frame update
    void Start()
    {
        Signal?.Invoke();
    }
}
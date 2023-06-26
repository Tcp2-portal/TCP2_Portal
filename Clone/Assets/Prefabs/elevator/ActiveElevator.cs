using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActiveElevator : MonoBehaviour
{
    public UnityEvent eventUp;
    public UnityEvent eventDown;
    private void OnTriggerEnter(Collider other)
    {
        this.eventUp.Invoke();
    }
    private void OnTriggerExit(Collider other)
    {
        this.eventDown.Invoke();
    
    }
}

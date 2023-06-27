using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActiveElevator : MonoBehaviour
{
    public UnityEvent eventEnter;
    public UnityEvent eventExit;
    public UnityEvent elevator;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetMouseButtonUp(0))
        {
            this.elevator.Invoke();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        this.eventEnter.Invoke();
    }
    private void OnTriggerExit(Collider other)
    {
        this.eventExit.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OpenNext : MonoBehaviour
{
   public UnityEvent next;
   void OnTriggerEnter(Collider other)
   {
       next.Invoke();
   }
}

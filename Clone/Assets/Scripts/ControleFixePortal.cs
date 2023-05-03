using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleFixePortal : MonoBehaviour
{
    public PortalPlacement portalPlacement;
    public List<Transform> target;
    private int index = 0;

    void Start()
    {
        if (target.Count > 0)
        {
            portalPlacement.FirePortal(index, target[0].position, target[0].forward, 50);
            target.RemoveAt(0);
            index++;
        }
    }
    void OnTriggerEnter(Collider other)
    {
         if (target.Count > 0)
        {
            portalPlacement.FirePortal(index, target[0].position, target[0].forward, 50);
            target.RemoveAt(0);
            index++;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleFixePortal : MonoBehaviour
{
    public PortalPlacement portalPlacement;
    public List<Transform> target;
    private int i = 0;

    public void Next()
    {
         if (target.Count > 0){
            portalPlacement.OpenPoratal(i, target[0].position, target[0].forward, 50);
            target.RemoveAt(0);
            i++;
        }
    }
}

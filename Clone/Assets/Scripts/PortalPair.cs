using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Scripts
{
    public class PortalPair : MonoBehaviour
    {
        public Portal[] Portals { private set; get; }

        private void Awake()
        {
            Portals = GetComponentsInChildren<Portal>();

            if (Portals.Length != 2)
            {
                Debug.LogError("PortalPair children must contain exactly two Portal components in total.");
            }
        }
    }
}
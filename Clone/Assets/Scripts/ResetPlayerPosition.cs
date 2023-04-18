using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class ResetPlayerPosition : MonoBehaviour
    {
        public MeshFilter levelGeon;
        public MeshFilter outPortal;
        private Vector3 vertex;

        void Start()
        {
            foreach (var vertex in levelGeon.mesh.vertices)
            {
                if (vertex.y < this.vertex.y)
                {
                    this.vertex = vertex;
                }
            }
        }
        void Update()
        {
            if (transform.position.y + GetComponent<MeshFilter>().mesh.bounds.size.y < vertex.y + levelGeon.transform.position.y)
            {
                transform.position = outPortal.mesh.bounds.center + outPortal.transform.position + Vector3.up * outPortal.mesh.bounds.size.y;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }
}

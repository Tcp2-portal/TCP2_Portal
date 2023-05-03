using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segurar_Box : MonoBehaviour
{
    public string[] Tags;
    public GameObject ObjSegurando, canvas;
    [Space(30)]
    public float _distanciaMax;
    public Transform t;
    public bool _segurando;
    public GameObject _local;
    public LayerMask _layerMask;

    void Update()
    {
        if (_segurando == true)
        {
            ObjSegurando.layer = LayerMask.NameToLayer("IgnoreBody");
            ObjSegurando.GetComponent<PortalableObject>().free = false;
            if (Input.GetKeyDown(KeyCode.E))
            {
                _segurando = false;

                ObjSegurando.layer = LayerMask.NameToLayer("Default");
                ObjSegurando.GetComponent<PortalableObject>().free = true;

                if (ObjSegurando.GetComponent<Rigidbody>())
                {
                    ObjSegurando.transform.parent = null;
                    ObjSegurando.GetComponent<Rigidbody>().isKinematic = false;
                }
                ObjSegurando = null;
                return;
            }

        }
        if (_segurando == false)
        {
            RaycastHit Hit = new RaycastHit();

            if (Physics.Raycast(t.position, t.forward, out Hit, _distanciaMax, _layerMask, QueryTriggerInteraction.Ignore))
            {

                for (int x = 0; x < Tags.Length; x++)
                {
                    if (Hit.transform.gameObject.tag == Tags[x])
                    {
                        Debug.DrawLine(t.position, Hit.point, Color.green);
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            _segurando = true;
                            ObjSegurando = Hit.transform.gameObject;
                            ObjSegurando.transform.position = _local.transform.position;
                            ObjSegurando.transform.rotation = _local.transform.rotation;
                            ObjSegurando.transform.parent = _local.transform;

                            if (ObjSegurando.GetComponent<Rigidbody>())
                            {
                                ObjSegurando.GetComponent<Rigidbody>().isKinematic = true;
                            }
                        }
                    }
                }
            }
        }
    }
}

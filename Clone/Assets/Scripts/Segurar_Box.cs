using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Segurar_Box : MonoBehaviour
{
    public string[] Tags;
    public GameObject ObjSegurando;
    [Space(30)]
    public float _distanciaMax;
    public Transform t;
    public bool _segurando;
    public GameObject _local;
    public LayerMask _layerMask;

    public GameObject lightBolt;
    public ParticleSystem particle;

private void Start()
{
}
    void Update()
    {
        if (_segurando == true)
        {
            ObjSegurando.layer = LayerMask.NameToLayer("IgnoreBody");
            ObjSegurando.GetComponent<PortalableObject>().free = false;
            lightBolt.SetActive(true);
            particle.Play();
            if (Input.GetKeyDown(KeyCode.E))
            {
                _segurando = false;

                ObjSegurando.layer = LayerMask.NameToLayer("Cube");
                ObjSegurando.GetComponent<PortalableObject>().free = true;

                if (ObjSegurando.GetComponent<Rigidbody>())
                {
                    ObjSegurando.transform.parent = null;
                    ObjSegurando.GetComponent<Rigidbody>().isKinematic = false;
                    
                    lightBolt.SetActive(false);
                    particle.Stop();
                }
                ObjSegurando = null;
                return;
            }

        }
        if (_segurando == false)
        {
            RaycastHit Hit = new RaycastHit();

            if (Physics.Raycast(t.position, t.forward, out Hit, _distanciaMax, _layerMask))
            {
                for (int x = 0; x < Tags.Length; x++)
                {
                    if (Hit.transform.gameObject.CompareTag(Tags[x]))
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

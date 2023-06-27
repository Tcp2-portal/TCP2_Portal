using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Segurar_Box : MonoBehaviour
{
    public string[] Tags;
    public GameObject ObjSegurando;
    [Space(30)]
    public float _distanciaMax;
    public Transform player;
    public Transform floor;
    public Transform t;
    public bool _segurando;
    public GameObject _local;
    public LayerMask _layerMask;

    public GameObject lightBolt;
    public ParticleSystem particle;

    private void Start()
    {
    }
    private IEnumerator ReleaseObjectDelayed()
    {
        yield return new WaitForSeconds(0.1f); 
        ObjSegurando.transform.parent = null;
        ObjSegurando.GetComponent<Rigidbody>().isKinematic = false;
        lightBolt.SetActive(false);
        particle.Stop();
        ObjSegurando.GetComponent<PortalableObject>().free = true;

        _segurando = false;
        Physics.IgnoreCollision(ObjSegurando.GetComponent<Collider>(), player.gameObject.GetComponent<Collider>(), false);
        Physics.Simulate(Time.fixedDeltaTime);
    }
    private void Update()
    {
        if (_segurando == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //ObjSegurando.layer = LayerMask.NameToLayer("Cube");
                Vector3 lastPos = ObjSegurando.transform.position;
                if (ObjSegurando.GetComponent<Rigidbody>())
                {
                    ObjSegurando.transform.parent = null;
                    ObjSegurando.GetComponent<Rigidbody>().isKinematic = false;

                    StartCoroutine(ReleaseObjectDelayed());
                }
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

                            //ObjSegurando.layer = LayerMask.NameToLayer("IgnoreBody");
                            Physics.IgnoreCollision(ObjSegurando.GetComponent<Collider>(), player.gameObject.GetComponent<Collider>(), true);
                            ObjSegurando.GetComponent<PortalableObject>().free = false;
                            lightBolt.SetActive(true);
                            particle.Play();

                        }
                    }
                }
            }
        }
    }
}

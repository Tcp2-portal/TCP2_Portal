using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Jobs;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;

public class Projectile : MonoBehaviour
{
    public Weapon gun;
    public float speed = 3.0f;
    public int id;
    PortalPlacement portalP;
    public LayerMask mask;
    public Material matPortal1;
    public Material matPortal2;

    private RaycastHit hit;
    private Vector3 startPosition;

    public void Initialize(Transform t, int portal)
    {
        transform.SetPositionAndRotation(t.position, t.rotation);
        Physics.Raycast(transform.position, transform.forward, out hit, 100, mask);
       
        if (hit.collider != null && (1 < hit.collider.gameObject.layer) & mask > 0)
        {
            startPosition = transform.position;
            gameObject.SetActive(true);
            Material mat = GetComponentInChildren<Renderer>().material;
            if (portal == 1)
            {
                mat = matPortal2;
            }
            else
            { 
                mat = matPortal1;
            }
            GetComponentInChildren<Renderer>().material = mat;
        }
        else
        {
            gun.GetComponent<Weapon>().Misfire();
        }
    }
    public void Update()
    {
        MoveFoward();
        ChackHit();
    }
    private void ChackHit()
    {
        if (Vector3.Distance(transform.position, startPosition) > Vector3.Distance(hit.point, startPosition))
        {
            gun.GetComponent<Weapon>().Hit(transform);
        }
    }
    private void MoveFoward()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}

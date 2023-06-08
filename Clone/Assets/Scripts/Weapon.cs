using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(PoolProjectiles))]
public class Weapon : MonoBehaviour
{
    public Transform t;
    private PoolProjectiles pool;
    public PortalPlacement portalP;
    public GameObject currentProjectile;
    private int portal;

    public int PortalActive { get => portal; set => portal = value; }

    public void Awake()
    {
        this.pool = GetComponent<PoolProjectiles>();
    }
    public void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Fire();
        }
    }
    public void Fire()
    {
        portalP.OpenPoratal(portal, t.position, t.forward, 250);
        // currentProjectile = pool.GetProjectile(0);
        // currentProjectile.transform.position = t.position;
        // currentProjectile.transform.forward = t.forward;
        // Debug.Log(pool.GetId(currentProjectile));
    }
    public void Hit(int id)
    {
        pool.PutProjectile(id);
    }
    public void Misfire()
    {
        Debug.LogWarning("faltando implementar misfire");
    }
}

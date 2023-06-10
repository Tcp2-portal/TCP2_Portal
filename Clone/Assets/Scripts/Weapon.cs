using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;

[RequireComponent(typeof(PoolProjectiles))]
public class Weapon : MonoBehaviour
{
    public Transform t;
    private PoolProjectiles pool;
    public PortalPlacement portalP;
    public GameObject currentProjectile;
    private int portal;

    private int i = 0;
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
        currentProjectile = pool.GetProjectile(0);
        currentProjectile.GetComponent<Projectile>().Initialize(t);
    }
    public void Hit(Transform bullet)
    {   
        portalP.OpenPoratal(portal, t.position, bullet.forward, 250);

    for(int i = 0; i < pool.poolSize; i++)
        {
            pool.PutProjectile(i);
        }
    }
    public void Misfire()
    {
        Debug.LogWarning("faltando implementar misfire");
    }
}

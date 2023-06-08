using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;

public class Projectile : MonoBehaviour
{
    public Weapon gun;
    public float speed = 3.0f;
    public int id;
    PortalPlacement portalP;
    private Quaternion startRotation;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        this.startRotation = transform.rotation;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LevelGeom"))
        {
            portalP.OpenPoratal(1, gun.t.position, gun.t.forward, 250.0f);
            gun.GetComponent<Weapon>().Hit(id);
        }
        else
        {
            gun.GetComponent<Weapon>().Misfire();
        }
    }
    public void Update()
    {
        MoveFoward();
    }
    private void MoveFoward()
    {
        transform.rotation = startRotation;
        transform.position += Vector3.forward * Time.deltaTime * speed;
    }
    private void ResetPosition()
    {
        transform.position = new Vector3(0, 0, 0);
    }
    void OnDisable()
    {
        ResetPosition();
    }
}

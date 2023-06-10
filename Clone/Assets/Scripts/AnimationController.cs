using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AnimationController : MonoBehaviour
{

    public Animator animation;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(rb.velocity.y > 0.1f)
        {
            animation.SetBool("Jump", true);
        }
        else if(rb.velocity.y < -0.1f)
        {
            animation.SetBool("Jump", false);
        }
    }

    public void Run(){
        animation.SetBool("Run", true);
    }
    public void Idle(){
        animation.SetBool("Run", false);
    }
}

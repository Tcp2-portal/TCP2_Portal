using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IKControl : MonoBehaviour
{
    public Transform leftHandObj;
    public Transform rightHandObj;
    public Transform lookObj;
  
    private Animator animator;

    void Start()
  {
      this.animator = GetComponent<Animator>();
  }
    void Update()
    {
    }
    void OnAnimatorIK(int layerIndex)
    {
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand,1);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand,1);  
        animator.SetIKPosition(AvatarIKGoal.RightHand,rightHandObj.position);
        animator.SetIKRotation(AvatarIKGoal.RightHand,rightHandObj.rotation);

        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,1);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand,1);  
        animator.SetIKPosition(AvatarIKGoal.LeftHand,leftHandObj.position);
        animator.SetIKRotation(AvatarIKGoal.LeftHand,leftHandObj.rotation);
    }
}

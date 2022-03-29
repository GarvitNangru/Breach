using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDoll : MonoBehaviour
{
    public Rigidbody[] rigidbodies;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodies= GetComponentsInChildren<Rigidbody>();
        animator= GetComponent<Animator>();
           DeactivateRagDoll();
      //  ActivateRagDoll();
    }
    public void DeactivateRagDoll()
    {
        foreach(var rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = true;  
        }
        animator.enabled = true;
    }
    public void ActivateRagDoll()
    {
        foreach (var rigidbody in rigidbodies)
        {
            rigidbody.isKinematic= false;
        }
        animator.enabled= false;
    }
    public void applyForce(Vector3 force)
    {
     //   Debug.Log("force applied :D");
        var rigidbody = animator.GetBoneTransform(HumanBodyBones.Hips).GetComponent<Rigidbody>();
        rigidbody.AddForce(force,ForceMode.Impulse);
    }
}

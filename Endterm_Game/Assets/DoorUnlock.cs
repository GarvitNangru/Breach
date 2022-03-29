using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    public Animator LockedDoorAnimator;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                LockedDoorAnimator.SetBool("DoorClose", false);
                LockedDoorAnimator.SetBool("DoorOpen", true);
            }
        }
    }
}

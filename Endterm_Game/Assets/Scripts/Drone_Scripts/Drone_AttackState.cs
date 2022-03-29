using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_AttackState : Drone_State
{

    public float firerate = 1f;
    private float nextTimeToFire = 0f;
    public void Enter(Drone_Ai agent)
    {
   //     Debug.Log("chal rha h enter");
   agent.navMeshAgent.isStopped = true;
    }
    public void Update(Drone_Ai agent)
    {
    //    Debug.Log("AttackState");
        //     Debug.Log("updating");
        //  agent.transform.LookAt(agent.playerTransform);
        Vector3 relativePos = agent.playerTransform.position - agent.transform.position;
        Quaternion toRotation = Quaternion.LookRotation(relativePos) * Quaternion.Inverse(Quaternion.Euler(0, 0, 0));
        agent.transform.rotation = Quaternion.Lerp(agent.transform.rotation, toRotation, 5.0f * Time.deltaTime);


        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / firerate;

            agent.shoot();
        }
        if(!agent.fieldOfView.canSeePlayer)
            agent.stateManager.changeState(DroneStateId.Patrol);
    }
    public void Exit(Drone_Ai agent)
    {
        agent.navMeshAgent.isStopped = false;
        agent.anim.ResetTrigger("Shoot");
    }

    public DroneStateId GetId()
    {
        return DroneStateId.attack;
    }
}

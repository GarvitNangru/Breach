using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : AiState
{
    public float firerate = 1f;
    private float nextTimeToFire = 0f;
    public AiStateId GetId()
    {
        return AiStateId.Attack;
    }
    public void Enter(Ai_Agent agent)
    {
        agent.weaponIK.setTargetTransform(agent.playerTransform);
        agent.anim.SetBool("Attack", true);
        agent.navMeshAgent.isStopped = true;
        Debug.Log("attacking");
    }
    public void Update(Ai_Agent agent)
    {
     //   agent.navMeshAgent.destination = agent.playerTransform.position;
      //  agent.transform.LookAt(agent.playerTransform);
        
        if (Time.time >= nextTimeToFire )
        {
            nextTimeToFire = Time.time + 1f / firerate;
          
            agent.shoot();
        }

        float distance = Vector3.Distance(agent.transform.position, agent.playerTransform.position);
        if (!agent._FieldOfView_Script.canSeePlayer)
        {
            agent.stateManager.changeState(AiStateId.chasePlayer);
        }

    }
    public void Exit(Ai_Agent agent)
    {
        Debug.Log("exit attack state");
      //  agent.anim.ResetTrigger("Attack");
        agent.anim.SetBool("Attack", false);
        agent.navMeshAgent.isStopped = false;
        agent.weaponIK.setTargetTransform(null);

    }
}

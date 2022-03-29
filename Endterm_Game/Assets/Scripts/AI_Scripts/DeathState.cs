using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : AiState
{
    public Vector3 direction;
     bool AlreadyCreated;
    public AiStateId GetId()
    {
        return AiStateId.Death;
    }
    public void Enter(Ai_Agent agent)
    {
        agent.transform.gameObject.layer = 14;
        agent.navMeshAgent.isStopped = true;
        agent.Canvas.SetActive(false);
        agent.ragDoll.ActivateRagDoll();
        direction.y = 1;
        agent.ragDoll.applyForce(direction * agent.agentConfig.dieForce);
       
        if (!AlreadyCreated)
        {
            agent.createHealZone();
            AlreadyCreated = true;
        }
        Debug.Log("deathState");

    //    agent.transform.gameObject.tag = "DeadEnemy";

    //    agent.EnemiesDead();
    }
    public void Update(Ai_Agent agent)
    {
    }
    public void Exit(Ai_Agent agent)
    {
 
    }

}

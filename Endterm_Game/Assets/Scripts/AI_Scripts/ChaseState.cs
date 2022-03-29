using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : AiState
{
    
  
    float timer = 0.0f;
    public AiStateId GetId()
    {
        return AiStateId.chasePlayer;
    }
    public void Enter(Ai_Agent agent)
    {
        agent.navMeshAgent.speed = 3;
    }
    public void Update(Ai_Agent agent)
    {
        if (!agent._FieldOfView_Script.canSeePlayer)
        {
            agent.stateManager.changeState(AiStateId.Patrol);
        }

        if (!agent.enabled)
        {
            return;
        }
        timer -= Time.deltaTime; // --------------------------------------------------------------------------------------
        if(!agent.navMeshAgent.hasPath)
        {
            agent.navMeshAgent.destination = agent.playerTransform.position;
        }
        if(timer<0.0f)
        {
            Vector3 direction = (agent.playerTransform.position - agent.navMeshAgent.destination);
            direction.y = 0;
            if(direction.sqrMagnitude>agent.agentConfig.maxDistance* agent.agentConfig.maxDistance)
            {
                if(agent.navMeshAgent.pathStatus !=NavMeshPathStatus.PathPartial)
                {
                    agent.navMeshAgent.destination = agent.playerTransform.position;
                }
            }
            timer = agent.agentConfig.maxTime;
        }
        float distance = Vector3.Distance(agent.transform.position, agent.navMeshAgent.destination);
        //if(distance<4f)
        //{
        //    agent.stateManager.changeState(AiStateId.Attack);
        //}
        if(agent._FieldOfView_Script.canSeePlayer && distance<4f)
            agent.stateManager.changeState(AiStateId.Attack);
    }
    public void Exit(Ai_Agent agent)
    {
    
    }

}
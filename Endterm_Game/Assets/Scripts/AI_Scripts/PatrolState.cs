using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : AiState
{
    int curIndex = 0;
    public AiStateId GetId()
    {
        return AiStateId.Patrol;
    }
    public void Enter(Ai_Agent agent)
    {
        agent.navMeshAgent.speed = 3;
    }

    void GoToNextPoint(Ai_Agent agent)
    { 
        agent.navMeshAgent.SetDestination(agent.wavePoints[curIndex].position);
        curIndex = (curIndex + 1) % agent.wavePoints.Length;
   //     Debug.Log(curIndex);
    }

    public void Update(Ai_Agent agent)
    {
        if (agent._FieldOfView_Script.canSeePlayer)
        {
            agent.stateManager.changeState(AiStateId.chasePlayer);
        }
        if (agent.navMeshAgent.remainingDistance < 1f && !agent.navMeshAgent.pathPending)
        {
            GoToNextPoint(agent);
        //  Debug.Log("CALLED");
        }
    }
    public void Exit(Ai_Agent agent)
    {

    }
}

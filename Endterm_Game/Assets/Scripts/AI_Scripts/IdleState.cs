using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : AiState
{
    public AiStateId GetId()
    {
        return AiStateId.Idle;
    }
    public void Enter(Ai_Agent agent)
    {
      
    }
    public void Update(Ai_Agent agent)
    {
        if(agent._FieldOfView_Script.canSeePlayer)
        {
            agent.stateManager.changeState(AiStateId.chasePlayer);
        }
    }
    public void Exit(Ai_Agent agent)
    {

    }
}

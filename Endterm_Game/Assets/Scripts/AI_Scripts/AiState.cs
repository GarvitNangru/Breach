using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AiStateId
{
    chasePlayer, 
    Death,
    Idle,
    Patrol,
    Attack
}
public interface AiState
{
    AiStateId GetId();
    void Enter(Ai_Agent agent);
    void Update(Ai_Agent agent);
    void Exit(Ai_Agent agent);
}

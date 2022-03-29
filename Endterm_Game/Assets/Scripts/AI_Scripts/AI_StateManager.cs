using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_StateManager 
{
    public AiState[] states;
    public Ai_Agent agent;
    public AiStateId currentState;
    public AI_StateManager(Ai_Agent agent)
    {
        this.agent = agent;
        int numStates=System.Enum.GetNames(typeof(AiStateId)).Length;
        states = new AiState[numStates];
    }
    public void RegisterState(AiState state)
    {
        int index = (int)state.GetId();
        states[index] = state;
    }
    public AiState GetState(AiStateId stateId)
    {
        int index = (int)stateId;
        return states[index];
    }
    public void Update()
    {
        GetState(currentState)?.Update(agent);
    }
    public void changeState(AiStateId newState)
    {
        GetState(currentState)?.Exit(agent);
        currentState = newState;
        GetState(currentState)?.Enter(agent);
    }
}

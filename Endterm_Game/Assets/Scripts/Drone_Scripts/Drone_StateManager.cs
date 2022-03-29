using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_StateManager
{
    public Drone_State[] states;
    public Drone_Ai agent;
    public DroneStateId currentState;
    public Drone_StateManager(Drone_Ai agent)
    {
        this.agent = agent;
        int numStates = System.Enum.GetNames(typeof(DroneStateId)).Length;
        states = new Drone_State[numStates];
    }
    public void RegisterState(Drone_State state)
    {
        int index = (int)state.GetId();
        states[index] = state;
    }
    public Drone_State GetState(DroneStateId stateId)
    {
        int index = (int)stateId;
        return states[index];
    }
    public void Update()
    {
        GetState(currentState)?.Update(agent);
    }
    public void changeState(DroneStateId newState)
    {
        GetState(currentState)?.Exit(agent);
        currentState = newState;
        GetState(currentState)?.Enter(agent);
    }
}

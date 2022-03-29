using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DroneStateId
{
    Idle,
    Patrol,
    attack,
    Death
}
public interface Drone_State
{
    DroneStateId GetId();
    void Enter(Drone_Ai agent);
    void Update(Drone_Ai agent);
    void Exit(Drone_Ai agent);
}

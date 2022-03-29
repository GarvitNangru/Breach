using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_idleState : Drone_State
{
    public void Enter(Drone_Ai agent)
    {
     //   Debug.Log("chal rha h enter");
    }
    public void Update(Drone_Ai agent)
    {
        //    Debug.Log("chal rha h");
 //       Debug.Log("idle");

        if (agent.fieldOfView.canSeePlayer)
        {
            agent.stateManager.changeState(DroneStateId.attack);
        }
    }
    public void Exit(Drone_Ai agent)
    {
     
    }

    public DroneStateId GetId()
    {
       return DroneStateId.Idle;
    }

   
}

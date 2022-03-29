using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_DeathState : Drone_State
{
    public void Enter(Drone_Ai agent)
    {
  //      agent.anim.SetBool("Dead", true);
   
    }
    public void Update(Drone_Ai agent)
    {
      
    }
    public void Exit(Drone_Ai agent)
    {

    }

    public DroneStateId GetId()
    {
        return DroneStateId.Death;
    }

}

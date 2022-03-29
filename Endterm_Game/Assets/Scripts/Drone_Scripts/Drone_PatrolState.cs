using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_PatrolState : Drone_State
{

    private int waypointIndex=0;
    private float dist;
    public void Enter(Drone_Ai agent)
    {
     //   Debug.Log("working");
    }

    public void Update(Drone_Ai agent)
    {
        //  Debug.Log("updating");
   //     Debug.Log("Patrolstate");


        //  agent.transform.position = Vector3.MoveTowards(agent.transform.position,agent.PatrolPoints[waypointIndex].position,4f * Time.deltaTime);
        agent.navMeshAgent.SetDestination(agent.PatrolPoints[waypointIndex].position);

        // agent.transform.LookAt(agent.PatrolPoints[waypointIndex]);

        Vector3 relativePos = agent.PatrolPoints[waypointIndex].position - agent.transform.position;
        Quaternion toRotation = Quaternion.LookRotation(relativePos) * Quaternion.Inverse(Quaternion.Euler(0, 0, 0));
        agent.transform.rotation = Quaternion.Lerp(agent.transform.rotation, toRotation, 5.0f * Time.deltaTime);

        dist = Vector3.Distance(agent.transform.position, agent.PatrolPoints[waypointIndex].position);
        if(dist<2f)
        {
            GotoNextWayPoint(agent);
        }
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
        return DroneStateId.Patrol;
    }

    public void GotoNextWayPoint(Drone_Ai drone)
    {
        if (waypointIndex == drone.PatrolPoints.Length-1)
            waypointIndex = 0;
        else
        waypointIndex++;
    }
}

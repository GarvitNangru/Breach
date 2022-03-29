using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Drone_Ai : MonoBehaviour
{
    // Start is called before the first frame update
    public Drone_StateManager stateManager;
    public DroneStateId initialState;

    public Transform[] PatrolPoints;
    public Animator anim;

    public Transform playerTransform;

    public FieldOfView fieldOfView;
    public NavMeshAgent navMeshAgent;
    RaycastHit hit;
    public GameObject projectiles;
    public Transform leftShootPoint;
    public Transform rightShootPoint;
    public float speed = 500;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        fieldOfView = GetComponent<FieldOfView>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        stateManager = new Drone_StateManager(this);
        stateManager.RegisterState(new Drone_idleState());
        stateManager.RegisterState(new Drone_PatrolState());
        stateManager.RegisterState(new Drone_AttackState());
        stateManager.RegisterState(new Drone_DeathState());
        stateManager.changeState(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        stateManager.Update();
    }
    
    public void shoot()
    {
        anim.SetTrigger("Shoot");
       
        Vector3 relativePos = playerTransform.position - transform.position;

        if (Physics.Raycast(transform.position,relativePos, out hit, 100f))
        {
       //     Debug.Log("shoot");
            GameObject projectile = Instantiate(projectiles, leftShootPoint.position, Quaternion.identity) as GameObject;
            GameObject projectile2 = Instantiate(projectiles, rightShootPoint.position, Quaternion.identity) as GameObject;
            projectile.transform.LookAt(hit.point);
            projectile2.transform.LookAt(hit.point);
            projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * speed);
            projectile2.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * speed);
         //   projectile.GetComponent<SciFiProjectileScript>().impactNormal = hit.normal;
        }
    }
}

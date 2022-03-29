using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai_Agent : MonoBehaviour
{
    // Start is called before the first frame update
    public AI_StateManager stateManager;
    public AiStateId inititalState;
    public NavMeshAgent navMeshAgent;
    public AiAgentConfig agentConfig;
    public RagDoll ragDoll;
    public Transform playerTransform;
    public GameObject aimPoint;
    public Transform[] wavePoints;
    public Animator anim;
    public GameObject Canvas;
    public GameManager gameManager;

    public FieldOfView _FieldOfView_Script;


    public GameObject healzonePosition;
    public GameObject HealZone;



    public GameObject projectiles;
    public float speed = 500;
    public WeaponIK weaponIK;
    void Start()
    {
        _FieldOfView_Script = GetComponent<FieldOfView>();  
        weaponIK=GetComponent<WeaponIK>();
        anim = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        ragDoll =GetComponent<RagDoll>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        stateManager = new AI_StateManager(this);
        stateManager.RegisterState(new ChaseState());
        stateManager.RegisterState(new DeathState());
        stateManager.RegisterState(new IdleState());
        stateManager.RegisterState(new PatrolState());
        stateManager.RegisterState(new AttackState());
        stateManager.changeState(inititalState);
    }

    // Update is called once per frame
    void Update()
    {
        stateManager.Update();
    }
  
    public void shoot()
    {
        anim.SetTrigger("Shoot");
     
        RaycastHit hit;
        if(Physics.Raycast(aimPoint.transform.position,aimPoint.transform.forward,out hit))
        {
            Debug.Log("BY ENEMY " + hit.collider.transform.name);
            GameObject projectile = Instantiate(projectiles, aimPoint.transform.position, Quaternion.identity) as GameObject;
      
            projectile.transform.LookAt(hit.point);
      
            projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * speed);
         
        }
    }
    public void createHealZone()
    {
        int num = Random.Range(0, 10);

        if (num % 2 != 0)
        {
            Destroy(this.gameObject, 2f);
            return;
        }

        Instantiate(HealZone, healzonePosition.transform.position, Quaternion.identity);
        Destroy(this.gameObject, 2f);
    }
   
}

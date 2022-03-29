using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth=100;
    public float curHealth;
    Ai_Agent agent;

    public Image healthbar;
    void Start()
    {
        agent = GetComponent<Ai_Agent>();
      
        curHealth = maxHealth;
        healthbar.fillAmount = curHealth/maxHealth;
        var rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach(var rigidbody in rigidbodies)
        {
         HitBox hitBox=   rigidbody.gameObject.AddComponent<HitBox>();
            hitBox.health = this;

        }
    }

    // Update is called once per frame
    public void TakeDamage(float amount,Vector3 direction)
    {
        curHealth -= amount;
        if(curHealth <= 0.0f)
        {
            die(direction);
        }
        healthbar.fillAmount = curHealth / maxHealth;
    }
    public void die(Vector3 direction)
    {
        DeathState deathState = agent.stateManager.GetState(AiStateId.Death) as DeathState;
        deathState.direction = direction;
        agent.stateManager.changeState(AiStateId.Death);

      
    //    Debug.Log("died");
    }
}

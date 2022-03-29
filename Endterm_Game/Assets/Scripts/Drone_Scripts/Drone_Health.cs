using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drone_Health : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 100;
    public float curHealth;
    Drone_Ai agent;

    public Image healthbar;
    public GameObject deathParticle;
    public Transform healZoneTransform;
    public GameObject healZone;
    void Start()
    {
        agent = GetComponent<Drone_Ai>();

        curHealth = maxHealth;
        healthbar.fillAmount = curHealth / maxHealth;
      
    }

    // Update is called once per frame
    public void TakeDamage(float amount)
    {
        curHealth -= amount;
        if (curHealth <= 0.0f)
        {
            die();
        }
        healthbar.fillAmount = curHealth / maxHealth;
    }
    public void die()
    {
        //       agent.stateManager.changeState(DroneStateId.Death);
        int num = Random.Range(0, 10);

        if (num % 2 != 0)
        {
           Instantiate(healZone, healZoneTransform.transform.position,Quaternion.identity);
        }
        GameObject go= Instantiate(deathParticle,transform.position,Quaternion.identity);
        Destroy(go,1.5f);
        Destroy(this.gameObject);
   //     Debug.Log("died");
    }
}

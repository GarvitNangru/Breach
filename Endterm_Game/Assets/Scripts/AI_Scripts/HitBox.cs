using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    // Start is called before the first frame update
    public AgentHealth health;

    public void OnRayCastHit(RifleGun gun,Vector3 direction)
    {
        health.TakeDamage(gun.damage,direction);
    }
}

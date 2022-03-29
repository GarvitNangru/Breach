using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthZone : MonoBehaviour
{
    // Start is called before the first frame update
    Player_Health player;
    RifleGun rifle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rifle= other.gameObject.GetComponentInChildren<RifleGun>();
            player =  other.gameObject.GetComponent<Player_Health>();
            rifle.maxAmmo += 30;
            rifle.currentAmmo = 30;
            player.curHealth = player.maxHealth;
            player.setHealthBar();

            Destroy(this.gameObject,0.2f);
        }
    }
}

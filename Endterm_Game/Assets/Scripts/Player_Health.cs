using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Player_Health : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth=100;
    public float curHealth;
    public GameManager manager;
    //    public Image healthbar;
    public TMP_Text healthText;
    public Slider healthbar;
    public UnityEvent DieEvent;
    void Start()
    {
        Time.timeScale = 1.0f;
        curHealth = maxHealth;
        setHealthBar();
    }
    public void takeDamage(float damage)
    {
        curHealth -= damage;

        if(curHealth <= 0)
        {
            die();
        }
        setHealthBar();
    }
    public void setHealthBar()
    {
        healthbar.value = curHealth / maxHealth;
        healthText.text = (healthbar.value * 100 ).ToString() + "%";
    }
    void die()
    {
        DieEvent.Invoke();
        //Time.timeScale = 0.0f;
        //manager.panelTobeActive("GameOverPanel");
        //Debug.Log("Player_Died");
    }
}

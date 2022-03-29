using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastDialogueActivate : MonoBehaviour
{
    public AgentHealth agentHealth;
    public GameObject LastDialogue;


    // Start is called before the first frame update
    void Start()
    {
        agentHealth = GetComponent<AgentHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(agentHealth.curHealth <=0)
        {
            LastDialogue.SetActive(true);
            Destroy(GetComponent<LastDialogueActivate>());
        }
    }
}

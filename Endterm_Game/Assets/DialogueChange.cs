using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueChange : MonoBehaviour
{

    public DialogueManagerLevel1 dialogueManagerLevel1;
    public int DialogueStopIndex;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogueManagerLevel1.stopIndex = DialogueStopIndex;
            dialogueManagerLevel1.index++;
            dialogueManagerLevel1.startDialogue();
            Invoke("DestroyGO", 0.1f);
        }
    }
    void DestroyGO()
    {
    Destroy(this.gameObject);
    }
}

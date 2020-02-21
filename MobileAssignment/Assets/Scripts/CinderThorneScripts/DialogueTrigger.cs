using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{    
    public Dialogue dialogue;

    void Start()
    {
        if (dialogue.textFile != null)
        {
            dialogue.sentences = (dialogue.textFile.text.Split('\n'));
        }
    }
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E) && FindObjectOfType<DialogueManager>().talking == false)
        {
            TriggerDialogue();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
        FindObjectOfType<DialogueManager>().sentences.Clear();
        FindObjectOfType<DialogueManager>().talking = false;
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}

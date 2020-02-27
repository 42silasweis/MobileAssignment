using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTextStuff : MonoBehaviour
{
    public bool tutorial = true;

    public Dialogue dialogue;


    void Start()
    {
        if (dialogue.textFile != null)
        {
            dialogue.sentences = (dialogue.textFile.text.Split('\n'));
        }
        //FindObjectOfType<DialogueManager>().sentences.Clear();
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }
    void Update()
    {

    }
}

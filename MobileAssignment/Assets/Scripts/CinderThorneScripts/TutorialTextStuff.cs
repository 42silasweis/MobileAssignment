using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTextStuff : MonoBehaviour
{
    public bool tutorial = true;

    public Dialogue dialogue;


    void Start()
    {
        //FindObjectOfType<DialogueManager>().sentences.Clear();
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Dialogue dialogue;

    public Text nameText;
    public Text dialogueText;

    public AudioSource SoundSource;
    public AudioClip buttonSound;

    public Animator animator;

    public Queue<string> sentences;
    float delay = 0.4f;
    float timer;
    public float delayTillNextSentence = 0.6f;
    float nextTimer;
    public bool talking;

    void Start()
    {
        sentences = new Queue<string>();
        if (dialogue.textFile != null)
        {
            dialogue.sentences = (dialogue.textFile.text.Split('\n'));
        }
        //FindObjectOfType<DialogueManager>().sentences.Clear();
        StartDialogue(dialogue);
    }

    void Update()
    {
        timer += Time.deltaTime;
        nextTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E) && timer > delay && nextTimer > delayTillNextSentence) // This makes it so pressing the E key will continue dialogue to the next sentence.
        {
            DisplayNextSentence();
            
            nextTimer = 0;
        } 
    }
    public void NextSentenceWithDelay()
    {
        if (nextTimer > delayTillNextSentence)
        {
            DisplayNextSentence();
            
            SoundSource.PlayOneShot(buttonSound, 0.2f); //plays the button sound
            nextTimer = 0;
        }
    }
    public void StartDialogue(Dialogue dialogue)
    {
        timer = 0;
        nextTimer = 0;

        //Debug.Log("Starting conversation with " + dialogue.name);

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        //Debug.Log(sentence);
    }
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        FindObjectOfType<LevelChanger>().FadeToLevel(2);
        //Debug.Log("EndDialogue thing");
        //Debug.Log("End of conversation");
    }
}

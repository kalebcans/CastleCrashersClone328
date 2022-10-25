using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    private GameObject player;
    private GameObject enemySpawner;
    public bool animationFinished = false;
    public bool coroutineRun;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        //Debug.Log("Starting conversation with " + dialogue.name);
        // float elapsed = 0;
        // while (elapsed < 3.0f)
        // {
        //     elapsed += Time.deltaTime;

        //     // yield return null;
        // }
        if(!coroutineRun)
        {
            coroutineRun = true;
            StartCoroutine(wait());
        }
        // sentences.Clear();d
        nameText.text = dialogue.name;


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
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        
        // StartCoroutine(wait());
        PauseGame();
    }
    public void EndDialogue()
    {
        ResumeGame();
        animator.SetBool("IsOpen", false);
    }

    // Update is called once per frame
    void PauseGame ()
    {
        Time.timeScale = 0.1f;
    }

    public IEnumerator wait()
    {
        float elapsed = 0;
         while (elapsed < 1.0f)
        {
            elapsed += Time.deltaTime;

            yield return null;
        }
        animationFinished = true;
        coroutineRun = false;
    }

    void ResumeGame ()
    {
        Time.timeScale = 1;
    }

}

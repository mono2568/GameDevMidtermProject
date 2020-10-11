using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences;
    public float interval = 0.05f;

    private GameObject parent;




    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue, GameObject p)
    {
        parent = p;
        nameText.text = dialogue.name;


        //保存用queueの中身を消去

        sentences.Clear();


        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        


        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {

        if (sentences.Count == 0)
        {
           EndDialogue();
           return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        
    }

    IEnumerator TypeSentence(string sentence)
    {
        //1フレームに1文字出るようにする
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(interval);
        }

    }
    void EndDialogue()
    {
        sentences.Clear();
        if(parent != null)parent.GetComponent<TalkTo>().setTalking(false);
    }
}

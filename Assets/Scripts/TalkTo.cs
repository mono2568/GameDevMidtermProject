using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkTo : MonoBehaviour
{
    public GameObject dialogueTrigger;
    private bool talking = false;
    private GameObject dialogueManager;
    private bool canTalk = false;
    public GameObject dialogueBox;

    // Update is called once per frame

    private void Start()
    {
        dialogueManager = GameObject.Find("DialogueManager");
        
    }
    void Update()
    {
    
        if (canTalk && !talking && Input.GetKeyDown(KeyCode.K))
        {
            dialogueBox.SetActive(true);
            dialogueTrigger.GetComponent<DialogueTrigger>().TriggerDialogue(this.gameObject);
            talking = true;
            
        }
        else if (canTalk && talking && Input.GetKeyDown(KeyCode.K))
        {
            dialogueManager.GetComponent<DialogueManager>().DisplayNextSentence();
        }
    }

    public void setTalking(bool b)
    {
        talking = b;
        if (!b) dialogueBox.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")canTalk = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") canTalk = false;
    }
}

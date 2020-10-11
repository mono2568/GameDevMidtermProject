using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextControler : MonoBehaviour
{
    public GameObject numberText;
    private GameObject slot1;
    private GameObject slot2;
    private GameObject slot3;
    public int number = 0;
    public AudioClip se;
    private void Start()
    {
        slot1 = GameObject.Find("Button1");
        slot2 = GameObject.Find("Button2");
        slot3 = GameObject.Find("Button3");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            slot1.GetComponent<SlotButton>().addNum(number);
            slot2.GetComponent<SlotButton>().addNum(number);
            slot3.GetComponent<SlotButton>().addNum(number);
            numberText.SetActive(true);
            this.GetComponent<AudioSource>().PlayOneShot(se);
            this.transform.position = new Vector3(0, 100, 0); 
        }
    }
}

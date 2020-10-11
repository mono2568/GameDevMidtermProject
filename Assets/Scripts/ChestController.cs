using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private float vMove = 0.3f;
    private float count = 0;
    private float vTime = 0.05f;
    private float hMove = 0.1f;
    private float countStart = -1f;
    private float textTimer = -1;
    private bool goUp = false;
    public GameObject clearText;
    public AudioClip se;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (countStart > 0)
        {
            countStart -= Time.deltaTime;
            if (countStart <= 0) goUp = true;

            if (count < vTime) count += Time.deltaTime;
            else
            {
                this.transform.Translate(vMove, 0, 0);
                vMove *= -1;
                count = 0;
            }
        }
        if (goUp)
        {
            this.transform.Translate(0, hMove, 0);
            if(textTimer == -1) textTimer = 3;
        }

        if(textTimer > 0)
        {
            textTimer -= Time.deltaTime;
            if (textTimer <= 0)
            {
                clearText.SetActive(true);
                textTimer = -2;
                this.GetComponent<AudioSource>().Stop();
            }
        }
    }

    public void startMove()
    {
        countStart = 5.0f;
        player.GetComponent<PlayerController>().shoesCollider.SetActive(true);
        this.GetComponent<AudioSource>().PlayOneShot(se);
    }
}

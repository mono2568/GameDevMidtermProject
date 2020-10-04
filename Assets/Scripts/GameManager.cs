using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject slot1;
    private GameObject slot2;
    private GameObject slot3;

    private int ans1 = 8;
    private int ans2 = 2;
    private int ans3 = 5;

    public GameObject chest;
    // Start is called before the first frame update
    void Start()
    {
        slot1 = GameObject.Find("Button1");
        slot2 = GameObject.Find("Button2");
        slot3 = GameObject.Find("Button3");
    }

    // Update is called once per frame
    void Update()
    {
        if(ans1 == slot1.GetComponent<SlotButton>().getNum() && ans2 == slot2.GetComponent<SlotButton>().getNum() && ans3 == slot3.GetComponent<SlotButton>().getNum())
        {
            chest.GetComponent<ChestController>().startMove();
            ans1 = -1;
        }
    }
}

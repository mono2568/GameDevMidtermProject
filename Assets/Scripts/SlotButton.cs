using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotButton : MonoBehaviour
{
    public Text slotText;
    private bool touch = false;
    private int[] activeNum = new int[10];
    private int num = 1;
    private int count = 0;
    public AudioClip se;

    private void Start()
    {
        activeNum[0] = 0;
    }
    private void Update()
    {
        if(touch && Input.GetKeyDown(KeyCode.K))
        {
            this.GetComponent<AudioSource>().PlayOneShot(se);
            count++;
            if (count >= num) count = 0;
            slotText.text = activeNum[count].ToString();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        touch = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        touch = false;
    }

    public void addNum(int n)
    {
        
        activeNum[num] = n;
        num++;
        for (int i = 1; i < num; i++)
        {
            var j = i;
            while(j-1 >= 0 && activeNum[j-1] > activeNum[j])
            {
                var tmp = activeNum[j - 1];
                activeNum[j-1] = activeNum[j];
                activeNum[j] = tmp;
                j--;
            }
        }

    }

    public int getNum()
    {
        return activeNum[count];

        
    }
}

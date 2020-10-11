using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatAppleManager : MonoBehaviour
{
    public int appleNum = 5;
    public GameObject[] appleSpr;
    public GameObject yesNo;

    public Text textBoy;

    public Sprite boyHappy;
    public Sprite boySad;
    public GameObject boy1Manager;
    public GameObject boy2Manager;
    public SpriteRenderer boy1Spr;
    public SpriteRenderer boy2Spr;

    private bool isEqual = false;

    public GameObject Gate;

    private void Update()
    {
        if (isEqual) Gate.transform.Translate(0.2f, 0, 0);
    }

    public int getAplleNum()
    {
        return appleNum;
    }

    public void eatApple()
    {
        
        if (appleNum == 0) return;
        if (!yesNo.activeSelf)
            yesNo.SetActive(true);
        else
        {
            if (yesNo.GetComponent<YesNoManager>().getAns())
            {
                appleNum--;
                Destroy(appleSpr[appleNum]);
            }
            yesNo.SetActive(false);
        }
        textBoy.text = appleNum.ToString();

        if(boy1Manager.GetComponent<EatAppleManager>().getAplleNum() > boy2Manager.GetComponent<EatAppleManager>().getAplleNum())
        {
            boy1Spr.GetComponent<SpriteRenderer>().sprite = boyHappy;
            boy2Spr.GetComponent<SpriteRenderer>().sprite = boySad;
        }
        else if (boy1Manager.GetComponent<EatAppleManager>().getAplleNum() < boy2Manager.GetComponent<EatAppleManager>().getAplleNum())
        {
            boy1Spr.GetComponent<SpriteRenderer>().sprite = boySad;
            boy2Spr.GetComponent<SpriteRenderer>().sprite = boyHappy;
        }
        else
        {
            boy1Spr.GetComponent<SpriteRenderer>().sprite = boyHappy;
            boy2Spr.GetComponent<SpriteRenderer>().sprite = boyHappy;
            isEqual = true;
        }
        

    }


}

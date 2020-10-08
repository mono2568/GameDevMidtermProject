using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesNoManager : MonoBehaviour
{
    public GameObject yesButton;
    public GameObject noButton;

    private bool ans = false; //false is no true is yes

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            yesButton.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
            noButton.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
            ans = false;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            yesButton.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
            noButton.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
            ans = true;
        }
 
    }

    public bool getAns()
    {
        return ans;
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SaveTextManager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

        if(this.GetComponent<Text>().color.a > 0) this.GetComponent<Text>().color -= new Color(0, 0, 0, Time.deltaTime);
    }

    public void startSaveText()
    {
        Debug.Log("StartSaveText");
        this.GetComponent<Text>().color += new Color(0, 0, 0, 1);
    }
}

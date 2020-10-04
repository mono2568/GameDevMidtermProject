using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJumpCollider : MonoBehaviour
{
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Player.GetComponent<PlayerController>().touchGround();
        }
    }
}

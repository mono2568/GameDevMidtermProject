using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdManager : MonoBehaviour
{
    public float span = 5.0f;
    private float count = 0;
    private GameObject Player;
    public float speed = 2.0f;
    private GameObject birdPrefab;
    private void Start()
    {
        Player = GameObject.Find("Player");
        birdPrefab = (GameObject)Resources.Load("Bird");
    }
    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if(count > span)
        {
            count = 0;
            float y = Random.Range(-2.0f, 10f);
            GameObject instance = (GameObject)Instantiate(birdPrefab, new Vector3(Player.transform.position.x + 25f, y, 0),Quaternion.identity);
            instance.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
        }
    }
}

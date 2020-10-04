using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.1f;
    public float turnTime = 2.0f;
    private float count = 0;

    private float rayDistance = 1.0f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        Ray2D ray;
        if (speed > 0) ray = new Ray2D(transform.position, new Vector2(1f, -1f));
        else ray = new Ray2D(transform.position, new Vector2(-1f, -1f));
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.blue);

        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, rayDistance);

        if(hit.collider == null || hit.collider.tag != "ground")
        {
            count = 0;
            speed *= -1;
            if (speed > 0) this.transform.localScale = new Vector3(-1.2f, 1.4f, 1.4f);
            else this.transform.localScale = new Vector3(1.2f, 1.4f, 1.4f);
        }

    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        count += Time.deltaTime;
        if (count >= turnTime)
        {
            count = 0;
            speed *= -1;
            if(speed > 0)this.transform.localScale = new Vector3(-1.4f, 1.4f, 1.4f);
            else this.transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
        }
        this.transform.Translate(speed, 0, this.transform.position.z);

    }
}

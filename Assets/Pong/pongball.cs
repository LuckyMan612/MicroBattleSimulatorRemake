using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class pongball : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("wybij", 2);
        direction = Vector2.one.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void wybij()
    {
        //GetComponent<Rigidbody2D>().AddForce((Vector2)transform.right + new Vector2(150, 0), ForceMode2D.Force);
    }
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            direction.y = -direction.y;
        }
        else if (collision.gameObject.CompareTag("Paddle"))
        {
            direction.x = -direction.x;
        }
    }
}

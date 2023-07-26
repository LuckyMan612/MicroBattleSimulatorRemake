using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed;
    public Vector3 up;
    public Vector3 down;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "left")
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position = transform.position + new Vector3(0, 0 + speed, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position = transform.position - new Vector3(0, 0 + speed, 0);
            }
        }
        if (gameObject.name == "right")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position = transform.position + new Vector3(0, 0 + speed, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position = transform.position - new Vector3(0, 0 + speed, 0);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "up")
        {
            transform.position = new Vector3(transform.position.x, up.y, transform.position.z);
        }
        else if (collision.gameObject.name == "down")
        {
            transform.position = new Vector3(transform.position.x, down.y, transform.position.z);
        }
    }
}

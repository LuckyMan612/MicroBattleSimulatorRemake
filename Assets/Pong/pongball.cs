using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pongball : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    [SerializeField] private ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.one.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        
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
            scoreManager.score++;
        }
        else if (collision.gameObject.CompareTag("Respawn"))
        {
            SceneManager.LoadScene("PongScene");
        }
    }
}

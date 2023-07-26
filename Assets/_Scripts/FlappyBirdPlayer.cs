using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyBirdPlayer : MonoBehaviour {

    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            Jump();
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            FlappyBirdManager.score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

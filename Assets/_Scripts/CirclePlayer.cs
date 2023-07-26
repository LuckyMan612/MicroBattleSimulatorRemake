using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CirclePlayer : MonoBehaviour {

    [SerializeField] private Transform cameraPrefab;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sprite;

    [SerializeField] private float jumpForce = 2f;

    [SerializeField] private Color colorPurple;
    [SerializeField] private Color colorCyan;
    [SerializeField] private Color colorPink;
    [SerializeField] private Color colorYellow;

    [SerializeField] private TextMeshProUGUI scoreCounter;

    private int score = -1;

    void Start()
    {
        ChangeColor();
    }

    void Update()
    {
        // If score is smaller then zero, then give score + 1 (becuz score is -1 at start)
        // else just give score
        scoreCounter.text = score < 0 ? $"{score + 1}" : $"{score}";

        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
            rb.velocity = Vector2.up * jumpForce;

        if ((transform.position.y - cameraPrefab.position.y) < -15f)
        {
            Restart();
        }

        if (score >= 5)
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColorChanger"))
        {
            Invoke("ChangeColor", 0.01f);
            score++;
        }
        else if (!collision.gameObject.CompareTag(tag))
        {
            Restart();
        }
    }

    void ChangeColor()
    {
        // We are changing colors based on the tag of the player
        // The tag is changed in ColorChanger.cs
        if (CompareTag("Purple"))
            sprite.color = colorPurple;
        else if (CompareTag("Cyan"))
            sprite.color = colorCyan;
        else if (CompareTag("Pink"))
            sprite.color = colorPink;
        else if (CompareTag("Yellow"))
            sprite.color = colorYellow;
    }

    void Restart()
    {
        score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

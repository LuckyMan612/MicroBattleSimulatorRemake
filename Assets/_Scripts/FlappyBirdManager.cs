using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FlappyBirdManager : MonoBehaviour {

    [SerializeField] private GameObject player;
    [SerializeField] private SpriteRenderer pressSpaceSprite;
    [SerializeField] private TextMeshProUGUI scoreCounter;

    private Rigidbody2D playerRB;

    public static int score;

    void Start()
    {
        player.GetComponent<NormalPlayer>().enabled = false;
        player.GetComponent<FlappyBirdPlayer>().enabled = true;
        playerRB = player.GetComponent<Rigidbody2D>();
        playerRB.gravityScale = 2.5f;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")) pressSpaceSprite.enabled = false;

        // Just setting the score
        // If smaller then zero, then give score + 1 (becuz score is -1 at start)
        // else just give score
        scoreCounter.text = score < 0 ? $"{score + 1}" : $"{score}";

        if (score >= 10)
        {
            score = 0;
            player.GetComponent<NormalPlayer>().enabled = true;
            player.GetComponent<FlappyBirdPlayer>().enabled = false;
            playerRB.gravityScale = 0f;
            SceneManager.LoadScene("MainScene");
        }
    }
}

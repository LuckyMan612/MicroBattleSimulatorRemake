using UnityEngine;

public class Pipe : MonoBehaviour {

    [SerializeField] private float moveSpeed;

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FlappyBirdManager.score += 1;
    }
}

using UnityEngine;

public class NormalPlayer : MonoBehaviour {

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        Vector2 tempVelocity = Vector2.zero;
        if (Input.GetAxisRaw("Horizontal") != 0f)
            tempVelocity.x = Input.GetAxisRaw("Horizontal");
        if (Input.GetAxisRaw("Vertical") != 0f)
            tempVelocity.y = Input.GetAxisRaw("Vertical");

        rb.velocity = tempVelocity.normalized * moveSpeed;
    }
}

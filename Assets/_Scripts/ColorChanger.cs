using UnityEngine;

public class ColorChanger : MonoBehaviour {

    private string[] colors = { "Purple", "Cyan", "Pink", "Yellow" };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int tempIndex = Random.Range(0, 4);
        collision.gameObject.tag = colors[tempIndex];
        Destroy(gameObject);
    }
}

using UnityEngine;

public class ColorSwitchCamera : MonoBehaviour {

    [SerializeField] private Transform target;
    [SerializeField] private float yOffset;

    void Update()
    {
        if (target.position.y + yOffset > transform.position.y) transform.position = new Vector3(target.position.x, target.position.y + yOffset, transform.position.z);
    }
}

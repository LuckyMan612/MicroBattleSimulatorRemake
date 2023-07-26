using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour
{
    public bool particles;
    public GameObject _particles;
    public Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (particles && position == transform.position)
        {
            _particles.SetActive(true);
        }
    }
}

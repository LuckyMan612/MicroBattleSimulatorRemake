using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour
{
    [Header("Particles")]
    public bool particles;
    public GameObject _particles;
    [Header("Sounds")]
    public bool sound;
    public GameObject _sound;
    [Header("Misc")]
    public bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sound && isMoving)
        {
            _sound.SetActive(true);
        } else _sound.SetActive(false);
        if (particles && isMoving)
        {
            _particles.SetActive(true);
        } else _particles.SetActive(false);
        

    }
}

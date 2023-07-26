using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int score;
    [SerializeField] private TextMeshProUGUI scoreTxT;
    [SerializeField] private int maxScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxT.text = score.ToString();
        if (score >= maxScore)
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}

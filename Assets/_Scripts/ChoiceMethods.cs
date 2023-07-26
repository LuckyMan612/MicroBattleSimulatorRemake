using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceMethods : MonoBehaviour {

    [SerializeField] private ChoiceSelector myChoiceSelector;

    [SerializeField] private SpriteRenderer playerSprite;

    // Don't change this in the Inspector, it is just being changed and accessed by scripts
    public string colorChosen;
    
    public List<Action> choiceMethods = new();

    [Header("Choices")]
    [SerializeField] private PlayerParticles pp; // and sounds


    private void Start()
    {
        choiceMethods.Add(ChoiceOne);
        choiceMethods.Add(ChoiceTwo);
        choiceMethods.Add(ChoiceThree);
        choiceMethods.Add(ChoiceFour);
    }

    private void ChoiceOne()
    {
        if (colorChosen == "Blue")
            playerSprite.color = Color.green;
        else
            playerSprite.color = Color.magenta;

        myChoiceSelector.AssignChoices();
    }

    private void ChoiceTwo()
    {
        if (colorChosen == "Blue")
        {
            SceneManager.LoadScene("FlappyBirdScene");
        }
        else
        {
            SceneManager.LoadScene("ColorSwitchScene");
        }
    }

    private void ChoiceThree()
    {
        if (colorChosen == "Blue") pp.sound = true;
        else pp.sound = false;
    }
    private void ChoiceFour()
    {
        if (colorChosen == "Blue") SceneManager.LoadScene("FlappyBirdScene");
        else SceneManager.LoadScene("PongScene");
    }
}

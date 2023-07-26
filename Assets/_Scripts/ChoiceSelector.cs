using TMPro;
using UnityEngine;

public class ChoiceSelector : MonoBehaviour {

    [SerializeField] private Transform playerTransform;

    [SerializeField] private TextMeshProUGUI blueChoiceText;
    [SerializeField] private TextMeshProUGUI redChoiceText;

    [SerializeField] private ChoiceMethods myChoiceMethods;

    [SerializeField] private Choice[] choiceTexts;

    public static int choiceIndex = -1;    
    public static System.Action<string> choiceMade;

    private void Awake()
    {
        choiceMade += ColorChosen;
        AssignChoices();
    }

    void ColorChosen(string color)
    {
        // Set the color first
        myChoiceMethods.colorChosen = color;
        // Then run the Method
        myChoiceMethods.choiceMethods[choiceIndex]();
    }

    public void AssignChoices()
    {
        ResetPosition();
        choiceIndex++;
        blueChoiceText.text = choiceTexts[choiceIndex].blueChoice;
        redChoiceText.text = choiceTexts[choiceIndex].redChoice;
    }

    private void ResetPosition()
    {
        playerTransform.position = Vector3.zero;
    }
}


// Make New Choices of your own if you want through the Inspector, make this game wha you want it to be :)
[System.Serializable]
public struct Choice
{
    public string blueChoice;
    public string redChoice;
}

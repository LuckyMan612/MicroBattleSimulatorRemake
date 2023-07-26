using UnityEngine;

public class BlueBox : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChoiceSelector.choiceMade?.Invoke("Blue");
    }
}

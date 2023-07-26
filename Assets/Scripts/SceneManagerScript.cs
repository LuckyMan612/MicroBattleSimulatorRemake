using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public void LoadScene(string scene)
    {
        StartCoroutine(LoadLevel(scene));
    }
    IEnumerator LoadLevel(string scene)
    {
        if(transition) transition.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(transitionTime);
        SceneManager.LoadScene(scene);
    }
}

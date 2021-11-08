using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    public Text tutorialText;
    void Start()
    {
        tutorialText.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            tutorialText.gameObject.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            tutorialText.gameObject.SetActive(false);
        }       
    }
}

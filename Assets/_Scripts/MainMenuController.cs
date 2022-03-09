using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button InstructionsButton;
    [SerializeField] private Button PlayGameButton;
    // Start is called before the first frame update
    private void OnEnable()
    {
        InstructionsButton.onClick.AddListener(() => ButtonCallBack(InstructionsButton));
        PlayGameButton.onClick.AddListener(() => ButtonCallBack(PlayGameButton));
    }

    private void ButtonCallBack(Button ButtonPressed){
        if (ButtonPressed == InstructionsButton)
        {
            Debug.Log("Here we should show the instructions");
        }
        else if (ButtonPressed == PlayGameButton)
        {
            Debug.Log("Should Go to Play game Scene");
        }
    }
}

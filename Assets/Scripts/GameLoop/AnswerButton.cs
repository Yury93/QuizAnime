using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI textButton;
    public Button Button => button;
    public TextMeshProUGUI TextButton => textButton;
    public void Init()
    {
        button.onClick.AddListener(GetTextButton);
        button.onClick.AddListener(GameStarter.Instance.QuizSystem.OnSelectAnswer);
    }
    public void GetTextButton()
    {
       GameStarter.Instance.QuizSystem.SetButtonAnswer(this);
    }
}

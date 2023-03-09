using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Girl : MonoBehaviour
{
    [SerializeField] private Image face;
    [SerializeField] private Sprite happy, angry, neitral;
    [SerializeField] private GameObject cloudSay;
    [SerializeField] private TextMeshProUGUI sayText;
    public void Init()
    {
        GameStarter.Instance.QuizSystem.OnPlayerReplied += ShowState;
        cloudSay.gameObject.SetActive(false);
    }
    private void ShowState(StateQuiz stateQuiz)
    {
        if(stateQuiz == StateQuiz.correctAnswer)
        {
            face.sprite = happy;
            cloudSay.gameObject.SetActive(true);
            sayText.text = "Правильно!";
        }
        else if(stateQuiz == StateQuiz.nonCorrectAnswer)
        {
            face.sprite = angry;
            cloudSay.gameObject.SetActive(true);
            sayText.text = "Не правильно!";
        }
        else
        {
            face.sprite = neitral;
            cloudSay.gameObject.SetActive(false);
        }
    }
}
